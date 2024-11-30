using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;


namespace MDI_Oleg
{
    public partial class FMDI : Form
    {
        private string ConnrctionString = "Data Source=C:\\Users\\Олег\\" +
            "Documents\\trbd\\MDI_Oleg\\oleg.db;Version=3;";
        private SQLiteConnection Connection;
        public FMDI()
        {
            InitializeComponent();
            Connection = new SQLiteConnection(ConnrctionString);
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
            //dataGridView1.DataSource = studentsTable;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void HorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void VerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void Table_Click(object sender, EventArgs e)
        {
            string table = (string)(sender as ToolStripMenuItem).Tag;
            var child = new Table(Connection, table);
            child.MdiParent = this;
            child.Show();
        }
    }
}
