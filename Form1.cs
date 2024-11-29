using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace MDI_Oleg
{
    public partial class Form1 : Form
    {
        private SQLiteConnection Connection;
        public Form1()
        {
            InitializeComponent();
            string path = "C:\\Users\\Олег\\Documents\\trbd\\MDI_Oleg\\oleg.db";
            Connection = new SQLiteConnection($"Data Source={path};Version=3");
            Connection.Open();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Connection.Close();
        }

        private void LoadStudents()
        {
            string query = "SELECT * FROM Client";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, Connection);
            DataTable studentsTable = new DataTable();
            adapter.Fill(studentsTable);
            dataGridView1.DataSource = studentsTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }
    }
}
