namespace MDI_Oleg
{
    partial class Table
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Table));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Create = new System.Windows.Forms.ToolStripButton();
            this.Edit = new System.Windows.Forms.ToolStripButton();
            this.Delete = new System.Windows.Forms.ToolStripButton();
            this.Exit = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Create,
            this.Edit,
            this.Delete,
            this.Exit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(426, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Create
            // 
            this.Create.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Create.Image = ((System.Drawing.Image)(resources.GetObject("Create.Image")));
            this.Create.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(24, 24);
            this.Create.Text = "Добавление данных";
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // Edit
            // 
            this.Edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(24, 24);
            this.Edit.Text = "Редактирование данных";
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Delete
            // 
            this.Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(24, 24);
            this.Delete.Text = "Удаление данных";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Exit
            // 
            this.Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(24, 24);
            this.Exit.Text = "Выход";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(426, 162);
            this.dataGridView1.TabIndex = 1;
            // 
            // Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 189);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Table";
            this.Text = "Table";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Create;
        private System.Windows.Forms.ToolStripButton Edit;
        private System.Windows.Forms.ToolStripButton Delete;
        private System.Windows.Forms.ToolStripButton Exit;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}