using System;
using System.Data.SQLite;
using System.Text.RegularExpressions;
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
            Model.Text = (String)row.Cells["Модель"].Value;
            Year.Value = (long)row.Cells["Год"].Value;
            Color.Text = (String)row.Cells["Цвет"].Value;
            Number.Text = (String)row.Cells["Номер"].Value;
        }
        public EditCar(SQLiteConnection Connection, Action onSave)
        {
            InitializeComponent();
            this.Connection = Connection;
            this.onSave = onSave;
        }

        bool validasion()
        {
            if (!IsValidNumberPlate(Number.Text))
            {
                MessageBox.Show("Введен некорректный формат номера машины", "Неправильный номер машины.", MessageBoxButtons.OK);
                return false;
            }
            if (Year.Value > DateTime.Today.Year)
            {
                MessageBox.Show(
                    "Не может быть год выпуска машины быть позже текущего",
                    "Некорректный год выпуска машины",
                    MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        private bool save()
        {
            var command = Connection.CreateCommand();
            if (!validasion() ) { return false; }
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
            return true;
        }

        private static bool IsValidNumberPlate(string plate)
        {
            string pattern = @"^[АВЕКМНОРСТУХ]{1} \d{3} [АВЕКМНОРСТУХ]{2} \d{2,3}$";
            return Regex.IsMatch(plate, pattern);
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

        private void EditCar_Load(object sender, EventArgs e)
        {

        }
    }
}
