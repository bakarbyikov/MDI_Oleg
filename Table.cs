using System;
using System.Data;
using System.Data.SQLite;
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
            this.Text = table;

            this.Connection = Connection;
            this.table = table;
            load();
            hide();

        }

        private void hide()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
                if (column.Name.Contains("ID"))
                    column.Visible = false;
        }

        private void load()
        {
            // TODO: use good sql client 
            var command = Connection.CreateCommand();
            switch (table)
            {
                case "Rent":
                    command.CommandText = $@"
                    SELECT 
	                    Client.ID as Client_ID,
	                    Client.Name,
	                    Car.ID as Car_ID,
	                    Car.Model,
	                    Car.Color,
	                    Rent.ID,
	                    Rent.Start,
	                    Rent.End,
	                    Rent.Price
                    FROM Rent
                    JOIN Car
                      ON Rent.Car = Car.ID 
                    JOIN Client
                      ON Rent.Client = Client.ID 
                    ";
                    break;
                case "Maintenance":
                    command.CommandText = $@"
                    SELECT 
                        Service.ID as Service_ID,
                        Service.Name,
                        Car.ID as Car_ID,
                        Car.Model,
                        Car.Color,
                        Maintenance.ID,
                        Maintenance.Start,
                        Maintenance.End,
                        Maintenance.Price
                    FROM Maintenance
                    JOIN Car
                      ON Maintenance.Car = Car.ID 
                    JOIN Service
                      ON Maintenance.Service = Service.ID 
                    ";
                    break;
                default:
                    command.CommandText = $"SELECT * FROM {table}";
                    break;
            }
            var adapter = new SQLiteDataAdapter(command);
            var studentsTable = new DataTable();
            adapter.Fill(studentsTable);
            dataGridView1.DataSource = studentsTable;
        }

        private void Delete_Click(object sender, System.EventArgs e)
        {
            // TODO ask before delete
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Нет данных для удаления!");
                return;
            }
            var target = dataGridView1.CurrentRow.Cells["ID"].Value;
            var command = Connection.CreateCommand();
            command.CommandText = $"DELETE FROM {table} WHERE ID = {target};";
            command.ExecuteNonQuery();
            load();
        }

        private void Edit_Click(object sender, System.EventArgs e)
        {
            Form child;
            switch (table)
            {
                case "Client":
                    child = new EditClient(Connection, load, dataGridView1.CurrentRow);
                    break;
                case "Car":
                    child = new EditCar(Connection, load, dataGridView1.CurrentRow);
                    break;
                default:
                    throw new Exception();
            }
            child.MdiParent = MdiParent;
            child.Show();
        }

        private void Create_Click(object sender, System.EventArgs e)
        {
            Form child;
            switch (table)
            {
                case "Client":
                    child = new EditClient(Connection, load);
                    break;
                case "Car":
                    child = new EditCar(Connection, load);
                    break;
                default:
                    throw new Exception();
            }
            child.MdiParent = MdiParent;
            child.Show();
        }
    }
}
