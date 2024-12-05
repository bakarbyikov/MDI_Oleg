using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace MDI_Oleg
{
    public partial class EditRent : Form
    {
        private SQLiteConnection Connection;
        private long? row_ID;
        private Action onSave;

        public EditRent(
            SQLiteConnection Connection,
            Action onSave,
            DataGridViewRow row
            ) : this(Connection, onSave)
        {
            row_ID = (long)row.Cells["ID"].Value;
            Start.Text = (String)row.Cells["Начало"].Value;
            End.Text = (String)row.Cells["Конец"].Value;
            Price.Text = (String)row.Cells["Цена"].Value.ToString();
            Client.SelectedIndex = Convert.ToInt32((long)row.Cells["Client_ID"].Value);
            Car.SelectedIndex = Convert.ToInt32((long)row.Cells["Car_ID"].Value);
        }
        public EditRent(SQLiteConnection Connection, Action onSave)
        {
            InitializeComponent();
            this.Connection = Connection;
            this.onSave = onSave;

            Start.Format = DateTimePickerFormat.Custom;
            Start.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            End.Format = DateTimePickerFormat.Custom;
            End.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            var tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Client"));
            var a = new SQLiteDataAdapter("SELECT ID, Name FROM Client", Connection);
            a.Fill(tmp.Tables["Client"]);

            Client.DisplayMember = tmp.Tables["Client"].Columns["Name"].ToString();
            Client.ValueMember = tmp.Tables["Client"].Columns["ID"].ToString();
            Client.DataSource = tmp.Tables["Client"];

            tmp.Tables.Add(new DataTable("Car"));
            var b = new SQLiteDataAdapter("SELECT ID, Model FROM Car", Connection);
            b.Fill(tmp.Tables["Car"]);
            Car.DisplayMember = tmp.Tables["Car"].Columns["Model"].ToString();
            Car.ValueMember = tmp.Tables["Car"].Columns["ID"].ToString();
            Car.DataSource = tmp.Tables["Car"];
        }
        private void save()
        {
            var command = Connection.CreateCommand();
            if (row_ID is null)
                command.CommandText = $@"
                    INSERT INTO Rent (Client, Car, Start, End, Price)
                    VALUES ($Client, $Car, $Start, $End, $Price);
                ";
            else
                command.CommandText = $@"
                    UPDATE Rent 
                    SET Client = $Client,
	                    Car = $Car,
	                    Start = $Start,
                        End = $End,
                        Price = $Price
                    WHERE ID = $ID; 
                ";
            command.Parameters.AddWithValue("$Client", Client.SelectedValue);
            command.Parameters.AddWithValue("$Car", Car.SelectedValue);
            command.Parameters.AddWithValue("$Start", Start.Text);
            command.Parameters.AddWithValue("$End", End.Text);
            command.Parameters.AddWithValue("$Price", Price.Text);
            command.Parameters.AddWithValue("$ID", row_ID);
            command.ExecuteNonQuery();
            onSave();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            save();
            this.Close();
        }
    }
}
