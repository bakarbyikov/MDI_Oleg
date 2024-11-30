using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI_Oleg
{
    public partial class EditClient : Form
    {
        private SQLiteConnection Connection;
        private long? row_ID;
        private Action onSave;

        public EditClient(
            SQLiteConnection Connection, 
            Action onSave, 
            DataGridViewRow row
            ) : this(Connection, onSave)
        {
            row_ID = (long)row.Cells["ID"].Value;
            Name_.Text = (String)row.Cells["Name"].Value;
            License.Text = (String)row.Cells["License"].Value;
            Birthday.Text = (String)row.Cells["Birthday"].Value;
            Phone.Text = (String)row.Cells["Phone"].Value;
        }
        public EditClient(SQLiteConnection Connection, Action onSave)
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
                    INSERT INTO Client (Name, License, Birthday, Phone)
                    VALUES ($Name, $License, $Birthday, $Phone);
                ";
            else
                command.CommandText = $@"
                    UPDATE Client 
                    SET Name = $Name,
	                    License = $License,
	                    Birthday = $Birthday,
	                    Phone = $Phone
                    WHERE ID = $ID; 
                ";
            command.Parameters.AddWithValue("$Name", Name_.Text);
            command.Parameters.AddWithValue("$License", License.Text);
            command.Parameters.AddWithValue("$Birthday", Birthday.Text);
            command.Parameters.AddWithValue("$Phone", Phone.Text);
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
