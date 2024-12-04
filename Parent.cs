using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;


namespace MDI_Oleg
{
    public partial class FMDI : Form
    {
        //private string ConnrctionString = "Data Source=C:\\Users\\Олег\\" + "Documents\\trbd\\MDI_Oleg\\oleg.db;Version=3;";
        private SQLiteConnection Connection;
        public FMDI()
        {
            InitializeComponent();
            //Connection = new SQLiteConnection(ConnrctionString);
            //Connection.Open();
        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Connection.Close();

            }
            catch
            {
                //ErrorConnection();
            }
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
            try
            {
                string table = (string)(sender as ToolStripMenuItem).Tag;
                var child = new Table(Connection, table);
                child.MdiParent = this;
                child.Show();
            }
            catch 
            {
                ErrorConnection();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = ".sqlite or .db files (*.db,*.sqlite)|*.db;*.sqlite|All Files (*.*)|*.*";
            string ConnrctionString;
            var connrction = openFileDialog.ShowDialog();
            if (connrction == DialogResult.OK)
            {
                ConnrctionString = openFileDialog.FileName;
                ConnectSQLite(ConnrctionString);
            }

        }
        private void ErrorConnection()
        {
            MessageBox.Show("Ошибка подключения к SQLite", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ConnectSQLite(string path)
        {
            try
            {
                Connection = new SQLiteConnection($"Data Source={path};Version=3;");
                Connection.Open();
            }
            catch 
            {
                ErrorConnection();
            }
        }

        private void AvailableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var child = new ReportFree(Connection);
            child.MdiParent = this;
            child.Show();
        }
    }
}
