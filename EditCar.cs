using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace MDI_Oleg
{
    public partial class EditCar : Form
    {
        private SQLiteConnection Connection;
        private long? row_ID;
        private Action onSave;

        public EditCar(
            SQLiteConnection Connection,
            Action onSave,
            DataGridViewRow row
            ) : this(Connection, onSave)
        {
            row_ID = (long)row.Cells["ID"].Value;
            Model.Text = (String)row.Cells["Model"].Value;
            Year.Text = row.Cells["Year"].Value.ToString();
            Color.Text = (String)row.Cells["Color"].Value;
            Number.Text = (String)row.Cells["Number"].Value;
        }
        public EditCar(SQLiteConnection Connection, Action onSave)
        {
            InitializeComponent();
            this.Connection = Connection;
            this.onSave = onSave;
        }
        private void save()
        {
            var command = Connection.CreateCommand();
            if (row_ID is null)
                command.CommandText = $@"
                    INSERT INTO Car (Model, Year, Color, Number)
                    VALUES ($Model, $Year, $Color, $Number);
                ";
            else
                command.CommandText = $@"
                    UPDATE Car 
                    SET Model = $Model,
	                    Year = $Year,
	                    Color = $Color,
	                    Number = $Number
                    WHERE ID = $ID; 
                ";
            command.Parameters.AddWithValue("$Model", Model.Text);
            command.Parameters.AddWithValue("$Year", Year.Text);
            command.Parameters.AddWithValue("$Color", Color.Text);
            command.Parameters.AddWithValue("$Number", Number.Text);
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
