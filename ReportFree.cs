﻿using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace MDI_Oleg
{
    public partial class ReportFree : Form
    {
        private SQLiteConnection Connection;
        public ReportFree(SQLiteConnection Connection)
        {
            this.Connection = Connection;
            InitializeComponent();
        }

        private void make_report(string path)
        {
            var command = Connection.CreateCommand();
            command.CommandText = $@"
                SELECT 
                  ID AS Код,
                  Model AS Модель, 
                  ""Year"" AS Год,
                  Color AS Цвет,
                  ""Number"" AS Номер
                FROM Car
                WHERE ID NOT IN (
                SELECT Car FROM Rent
                WHERE End > $Start
                  AND Start < $End
                UNION 
                SELECT Car FROM Maintenance
                WHERE End > $Start
                  AND Start < $End
                );";
            command.Parameters.AddWithValue("$Start", Start.Value);
            command.Parameters.AddWithValue("$End", End.Value);

            var adapter = new SQLiteDataAdapter(command);
            var Table = new DataTable();
            adapter.Fill(Table);

            var App = new Excel.Application();
            var Book = App.Workbooks.Add(System.Reflection.Missing.Value);
            var Sheet = (Excel.Worksheet)Book.Sheets[1];

            Sheet.Cells[1, 1] = $"Машины доступные для аренды с {Start.Value} по {End.Value}";
            for (int j = 0; j < Table.Columns.Count; j++)
            {
                Sheet.Cells[2, j + 1] = Table.Columns[j].ColumnName;
                for (int i = 0; i < Table.Rows.Count; i++)
                    Sheet.Cells[i + 3, j + 1] = Table.Rows[i][j];
            }
            Book.SaveAs(path);
            App.UserControl = true;
            App.Quit();
            MessageBox.Show("Отчет сформирован!");
        }

        private void Confirm_Click(object sender, System.EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            var path = saveFileDialog1.FileName;
            if (File.Exists(path))
                File.Delete(path);
            new Thread(() => { 
                make_report(saveFileDialog1.FileName); 
            }).Start();
        }

        private void Cancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
