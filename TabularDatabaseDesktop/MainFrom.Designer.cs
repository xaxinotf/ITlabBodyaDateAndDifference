namespace TabularDatabaseDesktop
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxTables;
        private System.Windows.Forms.Button btnCreateTable;
        private System.Windows.Forms.Button btnViewTable;
        private System.Windows.Forms.Button btnDeleteTable;
        private System.Windows.Forms.Button btnSaveDatabase;
        private System.Windows.Forms.Button btnLoadDatabase;

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
            this.listBoxTables = new System.Windows.Forms.ListBox();
            this.btnCreateTable = new System.Windows.Forms.Button();
            this.btnViewTable = new System.Windows.Forms.Button();
            this.btnDeleteTable = new System.Windows.Forms.Button();
            this.btnSaveDatabase = new System.Windows.Forms.Button();
            this.btnLoadDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // listBoxTables
            // 
            this.listBoxTables.FormattingEnabled = true;
            this.listBoxTables.Location = new System.Drawing.Point(12, 12);
            this.listBoxTables.Name = "listBoxTables";
            this.listBoxTables.Size = new System.Drawing.Size(200, 238);
            this.listBoxTables.TabIndex = 0;

            // 
            // btnCreateTable
            // 
            this.btnCreateTable.Location = new System.Drawing.Point(230, 12);
            this.btnCreateTable.Name = "btnCreateTable";
            this.btnCreateTable.Size = new System.Drawing.Size(120, 30);
            this.btnCreateTable.TabIndex = 1;
            this.btnCreateTable.Text = "Створити таблицю";
            this.btnCreateTable.UseVisualStyleBackColor = true;
            this.btnCreateTable.Click += new System.EventHandler(this.btnCreateTable_Click);

            // 
            // btnViewTable
            // 
            this.btnViewTable.Location = new System.Drawing.Point(230, 60);
            this.btnViewTable.Name = "btnViewTable";
            this.btnViewTable.Size = new System.Drawing.Size(120, 30);
            this.btnViewTable.TabIndex = 2;
            this.btnViewTable.Text = "Переглянути таблицю";
            this.btnViewTable.UseVisualStyleBackColor = true;
            this.btnViewTable.Click += new System.EventHandler(this.btnViewTable_Click);

            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.Location = new System.Drawing.Point(230, 110);
            this.btnDeleteTable.Name = "btnDeleteTable";
            this.btnDeleteTable.Size = new System.Drawing.Size(120, 30);
            this.btnDeleteTable.TabIndex = 3;
            this.btnDeleteTable.Text = "Видалити таблицю";
            this.btnDeleteTable.UseVisualStyleBackColor = true;
            this.btnDeleteTable.Click += new System.EventHandler(this.btnDeleteTable_Click);

            // 
            // btnSaveDatabase
            // 
            this.btnSaveDatabase.Location = new System.Drawing.Point(230, 160);
            this.btnSaveDatabase.Name = "btnSaveDatabase";
            this.btnSaveDatabase.Size = new System.Drawing.Size(120, 30);
            this.btnSaveDatabase.TabIndex = 4;
            this.btnSaveDatabase.Text = "Зберегти базу";
            this.btnSaveDatabase.UseVisualStyleBackColor = true;
            this.btnSaveDatabase.Click += new System.EventHandler(this.btnSaveDatabase_Click);

            // 
            // btnLoadDatabase
            // 
            this.btnLoadDatabase.Location = new System.Drawing.Point(230, 210);
            this.btnLoadDatabase.Name = "btnLoadDatabase";
            this.btnLoadDatabase.Size = new System.Drawing.Size(120, 30);
            this.btnLoadDatabase.TabIndex = 5;
            this.btnLoadDatabase.Text = "Завантажити базу";
            this.btnLoadDatabase.UseVisualStyleBackColor = true;
            this.btnLoadDatabase.Click += new System.EventHandler(this.btnLoadDatabase_Click);

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 270);
            this.Controls.Add(this.btnLoadDatabase);
            this.Controls.Add(this.btnSaveDatabase);
            this.Controls.Add(this.btnDeleteTable);
            this.Controls.Add(this.btnViewTable);
            this.Controls.Add(this.btnCreateTable);
            this.Controls.Add(this.listBoxTables);
            this.Name = "MainForm";
            this.Text = "Система управління табличною базою даних";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
