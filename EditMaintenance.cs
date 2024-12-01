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
    public partial class EditMaintenance : Form
    {
        private SQLiteConnection Connection;
        private long? row_ID;
        private Action onSave;

        public EditMaintenance(
            SQLiteConnection Connection,
            Action onSave,
            DataGridViewRow row
            ) : this(Connection, onSave)
        {
            row_ID = (long)row.Cells["ID"].Value;
            Start.Text = (String)row.Cells["Start"].Value;
            End.Text = (String)row.Cells["End"].Value;
            Price.Text = (String)row.Cells["Price"].Value.ToString();
            Service.SelectedIndex = Convert.ToInt32((long)row.Cells["Service_ID"].Value);
            Car.SelectedIndex = Convert.ToInt32((long)row.Cells["Car_ID"].Value);
        }
        public EditMaintenance(SQLiteConnection Connection, Action onSave)
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
            var a = new SQLiteDataAdapter("SELECT ID, Name FROM Service", Connection);
            a.Fill(tmp.Tables["Client"]);

            Service.DisplayMember = tmp.Tables["Client"].Columns["Name"].ToString();
            Service.ValueMember = tmp.Tables["Client"].Columns["ID"].ToString();
            Service.DataSource = tmp.Tables["Client"];

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
                    INSERT INTO Maintenance (Car, Service, Start, End, Price)
                    VALUES ($Car, $Service, $Start, $End, $Price);
                ";
            else
                command.CommandText = $@"
                    UPDATE Maintenance 
                    SET Car = $Car,
                        Service = $Service,
	                    Start = $Start,
                        End = $End,
                        Price = $Price
                    WHERE ID = $ID; 
                ";
            command.Parameters.AddWithValue("$Service", Service.SelectedValue);
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
