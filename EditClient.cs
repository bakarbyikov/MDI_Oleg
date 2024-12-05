using System;
using System.Data.SQLite;
using System.Text.RegularExpressions;
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
            Name_.Text = (String)row.Cells["ФИО"].Value;
            License.Text = (String)row.Cells["Права"].Value;
            Birthday.Text = (String)row.Cells["Дата рождения"].Value;
            Phone.Text = (String)row.Cells["Телефон"].Value;
        }
        public EditClient(SQLiteConnection Connection, Action onSave)
        {
            InitializeComponent();
            this.Connection = Connection;
            this.onSave = onSave;
        }

        bool validasion()
        {
            if (!IsValidLicense(License.Text))
            {
                MessageBox.Show(
                    "Принимается номер прав в формате '01 23 456789'",
                    "Некорректый формат прав",
                    MessageBoxButtons.OK);
                return false;
            }
            if ((DateTime.Now - Birthday.Value) < TimeSpan.FromDays(365 * 21))
            {
                MessageBox.Show(
                    "Не дорос еще машину арендовать, только с 21 можно.",
                    "Больно мал парнишка",
                    MessageBoxButtons.OK);
                return false;
            }
            if (!(IsValidRuPhoneNumber(Phone.Text)))
            {
                MessageBox.Show(
                    "Введен несуществующий номер телефона", 
                    "Неправильный формат номера телефона.", 
                    MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private bool save()
        {
            var command = Connection.CreateCommand();
            if (!validasion()) { return false; }

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
            command.Parameters.AddWithValue("$Birthday", 
                Birthday.Value.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("$Phone", Phone.Text);
            command.Parameters.AddWithValue("$ID", row_ID);
            command.ExecuteNonQuery();
            onSave();
            return true;
        }


        static bool IsValidRuPhoneNumber(string number)
        {
            string pattern = @"^\+7 \d{3} \d{3}-\d{2}-\d{2}$";
            return Regex.IsMatch(number, pattern);
        }

        static bool IsValidLicense(string license)
        {
            string pattern = @"^\d{2} \d{2} \d{6}$";
            return Regex.IsMatch(license, pattern);
        }


        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (save())
                this.Close();
        }
    }
}
