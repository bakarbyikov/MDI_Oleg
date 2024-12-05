using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace MDI_Oleg
{
    public partial class ReportCarStat : Form
    {
        private SQLiteConnection Connection;

        public ReportCarStat(SQLiteConnection Connection)
        {
            this.Connection = Connection;
            InitializeComponent();
        }

        private void make_report(string path)
        {
            var command = Connection.CreateCommand();
            command.CommandText = $@"
                SELECT 
                    Car.ID,
                    Model AS Модель,
                    Year AS Год,
                    Color AS Цвет,
                    Number AS Номер,
                    COUNT(Rent.id) AS ""Число аренд"",
                    COUNT(Maintenance.id) AS ""Число обслуживаний""
                FROM 
                    Car
                LEFT JOIN 
                    Rent ON Car.ID = Rent.Car
                LEFT JOIN 
                    Maintenance ON Car.ID = Maintenance.Car
                GROUP BY 
                    Car.ID;
            ";

            var adapter = new SQLiteDataAdapter(command);
            var Table = new DataTable();
            adapter.Fill(Table);

            var App = new Word.Application();
            var Document = App.Documents.Add();
            var Range = Document.Range();
            var Sheet = Document.Tables.Add(
                Range, Table.Rows.Count + 1, Table.Columns.Count + 1);

            var offset = 1;
            for (int j = 0; j < Table.Columns.Count; j++)
            {
                Sheet.Cell(offset, j + 1).Range
                    .InsertAfter(Table.Columns[j].ColumnName);
                for (int i = 0; i < Table.Rows.Count; i++)
                    Sheet.Cell(i + offset + 1, j + 1).Range
                        .InsertAfter($"{Table.Rows[i][j]}");
            }
            Document.Saved = true;
            Document.SaveAs(path);
            Document.Close();
            Document = null;
            App = null;
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
