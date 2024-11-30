using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI_Oleg
{
    public partial class Table : Form
    {
        private SQLiteConnection Connection;
        private string table;

        public Table(SQLiteConnection Connection, string table)
        {
            InitializeComponent();
            this.Connection = Connection;
            this.table = table;
            this.load(table);
            this.Text = table;
        }

        private void load(string table)
        {
            var command = Connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {table}";
            //command.Parameters.AddWithValue("@table", table);
            var adapter = new SQLiteDataAdapter(command);
            var studentsTable = new DataTable();
            adapter.Fill(studentsTable);
            dataGridView1.DataSource = studentsTable;
        }
    }
}
