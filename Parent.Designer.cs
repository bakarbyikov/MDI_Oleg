namespace MDI_Oleg
{
    partial class FMDI
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnotherTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AvailableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IncomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExpensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CascadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FIleToolStripMenuItem,
            this.TablesToolStripMenuItem,
            this.AnotherTablesToolStripMenuItem,
            this.ReportsToolStripMenuItem,
            this.WindowToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.WindowToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FIleToolStripMenuItem
            // 
            this.FIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.FIleToolStripMenuItem.Name = "FIleToolStripMenuItem";
            this.FIleToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FIleToolStripMenuItem.Text = "Файл";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // TablesToolStripMenuItem
            // 
            this.TablesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClientsToolStripMenuItem,
            this.CarsToolStripMenuItem,
            this.ServicesToolStripMenuItem});
            this.TablesToolStripMenuItem.Name = "TablesToolStripMenuItem";
            this.TablesToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
            this.TablesToolStripMenuItem.Text = "Основные таблицы";
            // 
            // ClientsToolStripMenuItem
            // 
            this.ClientsToolStripMenuItem.Name = "ClientsToolStripMenuItem";
            this.ClientsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ClientsToolStripMenuItem.Tag = "Client";
            this.ClientsToolStripMenuItem.Text = "Клиенты";
            this.ClientsToolStripMenuItem.Click += new System.EventHandler(this.Table_Click);
            // 
            // CarsToolStripMenuItem
            // 
            this.CarsToolStripMenuItem.Name = "CarsToolStripMenuItem";
            this.CarsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CarsToolStripMenuItem.Tag = "Car";
            this.CarsToolStripMenuItem.Text = "Машины";
            this.CarsToolStripMenuItem.Click += new System.EventHandler(this.Table_Click);
            // 
            // ServicesToolStripMenuItem
            // 
            this.ServicesToolStripMenuItem.Name = "ServicesToolStripMenuItem";
            this.ServicesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ServicesToolStripMenuItem.Tag = "Service";
            this.ServicesToolStripMenuItem.Text = "Сервисы";
            this.ServicesToolStripMenuItem.Click += new System.EventHandler(this.Table_Click);
            // 
            // AnotherTablesToolStripMenuItem
            // 
            this.AnotherTablesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RentToolStripMenuItem,
            this.MaintenanceToolStripMenuItem});
            this.AnotherTablesToolStripMenuItem.Name = "AnotherTablesToolStripMenuItem";
            this.AnotherTablesToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.AnotherTablesToolStripMenuItem.Text = "Еще таблицы";
            // 
            // RentToolStripMenuItem
            // 
            this.RentToolStripMenuItem.Name = "RentToolStripMenuItem";
            this.RentToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.RentToolStripMenuItem.Text = "Аренда";
            // 
            // MaintenanceToolStripMenuItem
            // 
            this.MaintenanceToolStripMenuItem.Name = "MaintenanceToolStripMenuItem";
            this.MaintenanceToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.MaintenanceToolStripMenuItem.Text = "Обслуживание";
            // 
            // ReportsToolStripMenuItem
            // 
            this.ReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AvailableToolStripMenuItem,
            this.IncomeToolStripMenuItem,
            this.ExpensesToolStripMenuItem});
            this.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem";
            this.ReportsToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.ReportsToolStripMenuItem.Text = "Отчеты";
            // 
            // AvailableToolStripMenuItem
            // 
            this.AvailableToolStripMenuItem.Name = "AvailableToolStripMenuItem";
            this.AvailableToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.AvailableToolStripMenuItem.Text = "Доступные машины";
            // 
            // IncomeToolStripMenuItem
            // 
            this.IncomeToolStripMenuItem.Name = "IncomeToolStripMenuItem";
            this.IncomeToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.IncomeToolStripMenuItem.Text = "Доходы";
            // 
            // ExpensesToolStripMenuItem
            // 
            this.ExpensesToolStripMenuItem.Name = "ExpensesToolStripMenuItem";
            this.ExpensesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.ExpensesToolStripMenuItem.Text = "Расходы";
            // 
            // WindowToolStripMenuItem
            // 
            this.WindowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CascadToolStripMenuItem,
            this.HorizontalToolStripMenuItem,
            this.VerticalToolStripMenuItem});
            this.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem";
            this.WindowToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.WindowToolStripMenuItem.Text = "Окно";
            // 
            // CascadToolStripMenuItem
            // 
            this.CascadToolStripMenuItem.Name = "CascadToolStripMenuItem";
            this.CascadToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.CascadToolStripMenuItem.Text = "Каскад";
            this.CascadToolStripMenuItem.Click += new System.EventHandler(this.CascadToolStripMenuItem_Click);
            // 
            // HorizontalToolStripMenuItem
            // 
            this.HorizontalToolStripMenuItem.Name = "HorizontalToolStripMenuItem";
            this.HorizontalToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.HorizontalToolStripMenuItem.Text = "Горизонтально";
            this.HorizontalToolStripMenuItem.Click += new System.EventHandler(this.HorizontalToolStripMenuItem_Click);
            // 
            // VerticalToolStripMenuItem
            // 
            this.VerticalToolStripMenuItem.Name = "VerticalToolStripMenuItem";
            this.VerticalToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.VerticalToolStripMenuItem.Text = "Вертикально";
            this.VerticalToolStripMenuItem.Click += new System.EventHandler(this.VerticalToolStripMenuItem_Click);
            // 
            // FMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MDI Oleg";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ServicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AnotherTablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MaintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AvailableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IncomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExpensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CascadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VerticalToolStripMenuItem;
    }
}

