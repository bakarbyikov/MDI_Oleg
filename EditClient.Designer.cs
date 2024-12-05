namespace MDI_Oleg
{
    partial class EditClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameLabel = new System.Windows.Forms.Label();
            this.Name_ = new System.Windows.Forms.TextBox();
            this.License = new System.Windows.Forms.TextBox();
            this.Birthday = new System.Windows.Forms.DateTimePicker();
            this.Phone = new System.Windows.Forms.TextBox();
            this.LicenseLabel = new System.Windows.Forms.Label();
            this.BirthdayLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Cancel = new System.Windows.Forms.Button();
            this.Confirm = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(4, 0);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 16);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "ФИО";
            // 
            // Name_
            // 
            this.Name_.Location = new System.Drawing.Point(153, 4);
            this.Name_.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name_.Name = "Name_";
            this.Name_.Size = new System.Drawing.Size(265, 22);
            this.Name_.TabIndex = 1;
            // 
            // License
            // 
            this.License.Location = new System.Drawing.Point(153, 57);
            this.License.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.License.Name = "License";
            this.License.Size = new System.Drawing.Size(265, 22);
            this.License.TabIndex = 2;
            // 
            // Birthday
            // 
            this.Birthday.Location = new System.Drawing.Point(153, 110);
            this.Birthday.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Birthday.Name = "Birthday";
            this.Birthday.Size = new System.Drawing.Size(265, 22);
            this.Birthday.TabIndex = 3;
            // 
            // Phone
            // 
            this.Phone.Location = new System.Drawing.Point(153, 163);
            this.Phone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(265, 22);
            this.Phone.TabIndex = 4;
            // 
            // LicenseLabel
            // 
            this.LicenseLabel.AutoSize = true;
            this.LicenseLabel.Location = new System.Drawing.Point(4, 53);
            this.LicenseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LicenseLabel.Name = "LicenseLabel";
            this.LicenseLabel.Size = new System.Drawing.Size(49, 16);
            this.LicenseLabel.TabIndex = 5;
            this.LicenseLabel.Text = "Права";
            // 
            // BirthdayLabel
            // 
            this.BirthdayLabel.AutoSize = true;
            this.BirthdayLabel.Location = new System.Drawing.Point(4, 106);
            this.BirthdayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BirthdayLabel.Name = "BirthdayLabel";
            this.BirthdayLabel.Size = new System.Drawing.Size(106, 16);
            this.BirthdayLabel.TabIndex = 6;
            this.BirthdayLabel.Text = "Дата рождения";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Location = new System.Drawing.Point(4, 159);
            this.PhoneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(67, 16);
            this.PhoneLabel.TabIndex = 7;
            this.PhoneLabel.Text = "Телефон";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66667F));
            this.tableLayoutPanel1.Controls.Add(this.NameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PhoneLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Name_, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Phone, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.BirthdayLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Birthday, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.LicenseLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.License, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(39, 36);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(448, 214);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(279, 251);
            this.Cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(100, 28);
            this.Cancel.TabIndex = 8;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(387, 251);
            this.Confirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(100, 28);
            this.Confirm.TabIndex = 9;
            this.Confirm.Text = "Сохранить";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // EditClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(561, 322);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.Cancel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EditClient";
            this.Text = "EditClient";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox Name_;
        private System.Windows.Forms.TextBox License;
        private System.Windows.Forms.DateTimePicker Birthday;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.Label LicenseLabel;
        private System.Windows.Forms.Label BirthdayLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Confirm;
    }
}