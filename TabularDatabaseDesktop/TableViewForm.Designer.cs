namespace TabularDatabaseDesktop
{
    partial class TableViewForm
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Очищення ресурсів, які використовуються.
        /// </summary>
        /// <param name="disposing">істина, якщо керовані ресурси мають бути утилізовані; інакше — хибність.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, згенерований Конструктором Windows Forms

        /// <summary>
        /// Метод для ініціалізації компонентів форми.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnEditRow = new System.Windows.Forms.Button();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnDifference = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(600, 300);
            this.dataGridView.TabIndex = 0;
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(12, 330);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(120, 30);
            this.btnAddRow.TabIndex = 1;
            this.btnAddRow.Text = "Додати рядок";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnEditRow
            // 
            this.btnEditRow.Location = new System.Drawing.Point(150, 330);
            this.btnEditRow.Name = "btnEditRow";
            this.btnEditRow.Size = new System.Drawing.Size(120, 30);
            this.btnEditRow.TabIndex = 2;
            this.btnEditRow.Text = "Редагувати рядок";
            this.btnEditRow.UseVisualStyleBackColor = true;
            this.btnEditRow.Click += new System.EventHandler(this.btnEditRow_Click);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Location = new System.Drawing.Point(288, 330);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(120, 30);
            this.btnDeleteRow.TabIndex = 3;
            this.btnDeleteRow.Text = "Видалити рядок";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // btnDifference
            // 
            this.btnDifference.Location = new System.Drawing.Point(432, 330);
            this.btnDifference.Name = "btnDifference";
            this.btnDifference.Size = new System.Drawing.Size(180, 30);
            this.btnDifference.TabIndex = 4;
            this.btnDifference.Text = "Різниця таблиць";
            this.btnDifference.UseVisualStyleBackColor = true;
            this.btnDifference.Click += new System.EventHandler(this.btnDifference_Click);
            // 
            // TableViewForm
            // 
            this.ClientSize = new System.Drawing.Size(624, 381);
            this.Controls.Add(this.btnDifference);
            this.Controls.Add(this.btnDeleteRow);
            this.Controls.Add(this.btnEditRow);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.dataGridView);
            this.Name = "TableViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Перегляд таблиці";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnEditRow;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Button btnDifference;
    }
}
