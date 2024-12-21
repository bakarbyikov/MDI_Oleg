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
                case "Client":
                    this.Text = "Клиент";
                    command.CommandText = $@"
                        SELECT 
                          ID,
                          Name AS ФИО,
                          License AS Права,
                          Birthday AS ""Дата рождения"",
                          Phone AS Телефон
                        FROM Client";
                    break;
                case "Car":
                    this.Text = "Машина";
                    command.CommandText = $@"
                        SELECT 
                          ID,
                          Model AS Модель, 
                          ""Year"" AS Год,
                          Color AS Цвет,
                          ""Number"" AS Номер
                        FROM Car";
                    break;
                case "Service":
                    this.Text = "Сервис";
                    command.CommandText = $@"
                        SELECT 
                          ID,
                          Name AS Название,
                          Address AS Адрес,
                          Payment_details AS Реквизиты
                        FROM Service";
                    break;
                case "Rent":
                    this.Text = "Аренда";
                    command.CommandText = $@"
                    SELECT 
	                    Client.ID as Client_ID,
	                    Client.Name as Клиент,
	                    Car.ID as Car_ID,
	                    Car.Model as Модель,
	                    Car.Color as Цвет,
	                    Rent.ID,
	                    Rent.Start as Начало,
	                    Rent.End as Конец,
	                    Rent.Price as Цена
                    FROM Rent
                    JOIN Car
                      ON Rent.Car = Car.ID 
                    JOIN Client
                      ON Rent.Client = Client.ID 
                    ";
                    break;
                case "Maintenance":
                    this.Text = "Обслуживание";
                    command.CommandText = $@"
                    SELECT 
                        Service.ID as Service_ID,
                        Service.Name as Название,
                        Car.ID as Car_ID,
                        Car.Model as Модель,
                        Car.Color as Цвет,
                        Maintenance.ID,
                        Maintenance.Start as Начало,
                        Maintenance.End as Конец,
                        Maintenance.Price as Цена
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
            dataGridView1.ReadOnly = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }


        private void Delete_Click(object sender, System.EventArgs e)
        {
            var confirmResult = MessageBox.Show("Вы точно хотите удалить?",
                                     "Подтвердите удаление",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
                return;
            
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
                case "Service":
                    child = new EditService(Connection, load, dataGridView1.CurrentRow);
                    break;
                case "Rent":
                    child = new EditRent(Connection, load, dataGridView1.CurrentRow);
                    break;
                case "Maintenance":
                    child = new EditMaintenance(Connection, load, dataGridView1.CurrentRow);
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
                case "Service":
                    child = new EditService(Connection, load);
                    break;
                case "Rent":
                    child = new EditRent(Connection, load);
                    break;
                case "Maintenance":
                    child = new EditMaintenance(Connection, load);
                    break;
                default:
                    throw new Exception();
            }
            child.MdiParent = MdiParent;
            child.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Table_Load(object sender, EventArgs e)
        {
            load();
            hide();
            var w = dataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 88;
            this.MinimumSize = new System.Drawing.Size(w, 100);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            load();
        }
    }
}
