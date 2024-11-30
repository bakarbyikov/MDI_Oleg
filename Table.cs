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
            this.load(table);
            hide();
        }

        private void hide()
        {
            
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name.Contains("ID"))
                    column.Visible = false;
            }
                
        }

        private void load(string table)
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
    }
}
