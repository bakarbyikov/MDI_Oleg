using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace MDI_Oleg
{
    public partial class EditService : Form
    {
        private SQLiteConnection Connection;
        private long? row_ID;
        private Action onSave;

        public EditService(
            SQLiteConnection Connection,
            Action onSave,
            DataGridViewRow row
            ) : this(Connection, onSave)
        {
            row_ID = (long)row.Cells["ID"].Value;
            Name_.Text = (String)row.Cells["Name"].Value;
            Address.Text = (String)row.Cells["Address"].Value;
            Payment_details.Text = (String)row.Cells["Payment_details"].Value;
        }
        public EditService(SQLiteConnection Connection, Action onSave)
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
                    INSERT INTO Service (Name, Address, Payment_details)
                    VALUES ($Name, $Address, $Payment_details);
                ";
            else
                command.CommandText = $@"
                    UPDATE Service 
                    SET Name = $Name,
	                    Address = $Address,
	                    Payment_details = $Payment_details
                    WHERE ID = $ID; 
                ";
            command.Parameters.AddWithValue("$Name", Name_.Text);
            command.Parameters.AddWithValue("$Address", Address.Text);
            command.Parameters.AddWithValue("$Payment_details", Payment_details.Text);
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
