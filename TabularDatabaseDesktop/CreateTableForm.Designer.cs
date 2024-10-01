using System.Windows.Forms;

namespace TabularDatabaseDesktop
{
    partial class CreateTableForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.TextBox txtFieldName;
        private System.Windows.Forms.Label lblFieldName;
        private System.Windows.Forms.ComboBox cmbDataType;
        private System.Windows.Forms.Label lblDataType;
        private System.Windows.Forms.Label lblDataTypeHint;
        private System.Windows.Forms.Button btnAddField;
        private System.Windows.Forms.Button btnRemoveField;
        private System.Windows.Forms.Button btnEditField;
        private System.Windows.Forms.ListBox listBoxFields;
        private System.Windows.Forms.Label lblFields;
        private System.Windows.Forms.Label lblFieldNameHint;
        private System.Windows.Forms.Button btnCreateTable;
        private System.Windows.Forms.Label lblFieldsCount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.lblTableName = new System.Windows.Forms.Label();
            this.txtFieldName = new System.Windows.Forms.TextBox();
            this.lblFieldName = new System.Windows.Forms.Label();
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.lblDataType = new System.Windows.Forms.Label();
            this.lblDataTypeHint = new System.Windows.Forms.Label();
            this.btnAddField = new System.Windows.Forms.Button();
            this.btnRemoveField = new System.Windows.Forms.Button();
            this.btnEditField = new System.Windows.Forms.Button();
            this.listBoxFields = new System.Windows.Forms.ListBox();
            this.lblFields = new System.Windows.Forms.Label();
            this.lblFieldNameHint = new System.Windows.Forms.Label();
            this.btnCreateTable = new System.Windows.Forms.Button();
            this.lblFieldsCount = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // txtTableName
            this.txtTableName.Location = new System.Drawing.Point(150, 20);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(200, 20);
            this.txtTableName.TabIndex = 0;

            // lblTableName
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(20, 23);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(85, 13);
            this.lblTableName.TabIndex = 1;
            this.lblTableName.Text = "Назва таблиці:";

            // txtFieldName
            this.txtFieldName.Location = new System.Drawing.Point(150, 60);
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.Size = new System.Drawing.Size(200, 20);
            this.txtFieldName.TabIndex = 2;

            // lblFieldName
            this.lblFieldName.AutoSize = true;
            this.lblFieldName.Location = new System.Drawing.Point(20, 63);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(68, 13);
            this.lblFieldName.TabIndex = 3;
            this.lblFieldName.Text = "Назва поля:";

            // cmbDataType
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Location = new System.Drawing.Point(150, 100);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(200, 21);
            this.cmbDataType.TabIndex = 4;

            // lblDataType
            this.lblDataType.AutoSize = true;
            this.lblDataType.Location = new System.Drawing.Point(20, 103);
            this.lblDataType.Name = "lblDataType";
            this.lblDataType.Size = new System.Drawing.Size(65, 13);
            this.lblDataType.TabIndex = 5;
            this.lblDataType.Text = "Тип даних:";

            // lblDataTypeHint
            this.lblDataTypeHint.AutoSize = true;
            this.lblDataTypeHint.Location = new System.Drawing.Point(150, 130);
            this.lblDataTypeHint.Name = "lblDataTypeHint";
            this.lblDataTypeHint.Size = new System.Drawing.Size(180, 13);
            this.lblDataTypeHint.TabIndex = 6;
            this.lblDataTypeHint.Text = "Виберіть тип даних для нового поля.";

            // btnAddField
            this.btnAddField.Location = new System.Drawing.Point(380, 60);
            this.btnAddField.Name = "btnAddField";
            this.btnAddField.Size = new System.Drawing.Size(90, 23);
            this.btnAddField.TabIndex = 7;
            this.btnAddField.Text = "Додати поле";
            this.btnAddField.UseVisualStyleBackColor = true;
            this.btnAddField.Click += new System.EventHandler(this.btnAddField_Click);

            // btnRemoveField
            this.btnRemoveField.Location = new System.Drawing.Point(380, 100);
            this.btnRemoveField.Name = "btnRemoveField";
            this.btnRemoveField.Size = new System.Drawing.Size(90, 23);
            this.btnRemoveField.TabIndex = 8;
            this.btnRemoveField.Text = "Видалити поле";
            this.btnRemoveField.UseVisualStyleBackColor = true;
            this.btnRemoveField.Click += new System.EventHandler(this.btnRemoveField_Click);

            // btnEditField
            this.btnEditField.Location = new System.Drawing.Point(380, 140);
            this.btnEditField.Name = "btnEditField";
            this.btnEditField.Size = new System.Drawing.Size(90, 23);
            this.btnEditField.TabIndex = 9;
            this.btnEditField.Text = "Редагувати";
            this.btnEditField.UseVisualStyleBackColor = true;
            this.btnEditField.Click += new System.EventHandler(this.btnEditField_Click);

            // listBoxFields
            this.listBoxFields.FormattingEnabled = true;
            this.listBoxFields.Location = new System.Drawing.Point(150, 180);
            this.listBoxFields.Name = "listBoxFields";
            this.listBoxFields.Size = new System.Drawing.Size(200, 95);
            this.listBoxFields.TabIndex = 10;

            // lblFields
            this.lblFields.AutoSize = true;
            this.lblFields.Location = new System.Drawing.Point(20, 180);
            this.lblFields.Name = "lblFields";
            this.lblFields.Size = new System.Drawing.Size(84, 13);
            this.lblFields.TabIndex = 11;
            this.lblFields.Text = "Список полів:";

            // lblFieldNameHint
            this.lblFieldNameHint.AutoSize = true;
            this.lblFieldNameHint.Location = new System.Drawing.Point(150, 160);
            this.lblFieldNameHint.Name = "lblFieldNameHint";
            this.lblFieldNameHint.Size = new System.Drawing.Size(220, 13);
            this.lblFieldNameHint.TabIndex = 12;
            this.lblFieldNameHint.Text = "Введіть назву та натисніть 'Додати поле'.";

            // lblFieldsCount
            this.lblFieldsCount.AutoSize = true;
            this.lblFieldsCount.Location = new System.Drawing.Point(150, 280);
            this.lblFieldsCount.Name = "lblFieldsCount";
            this.lblFieldsCount.Size = new System.Drawing.Size(134, 13);
            this.lblFieldsCount.TabIndex = 13;
            this.lblFieldsCount.Text = "Загальна кількість полів: 0";

            // btnCreateTable
            this.btnCreateTable.Location = new System.Drawing.Point(150, 300);
            this.btnCreateTable.Name = "btnCreateTable";
            this.btnCreateTable.Size = new System.Drawing.Size(200, 30);
            this.btnCreateTable.TabIndex = 14;
            this.btnCreateTable.Text = "Створити таблицю";
            this.btnCreateTable.UseVisualStyleBackColor = true;
            this.btnCreateTable.Click += new System.EventHandler(this.btnCreateTable_Click);

            // CreateTableForm
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.btnCreateTable);
            this.Controls.Add(this.lblFieldsCount);
            this.Controls.Add(this.lblFieldNameHint);
            this.Controls.Add(this.lblFields);
            this.Controls.Add(this.listBoxFields);
            this.Controls.Add(this.btnEditField);
            this.Controls.Add(this.btnRemoveField);
            this.Controls.Add(this.btnAddField);
            this.Controls.Add(this.lblDataTypeHint);
            this.Controls.Add(this.lblDataType);
            this.Controls.Add(this.cmbDataType);
            this.Controls.Add(this.lblFieldName);
            this.Controls.Add(this.txtFieldName);
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.txtTableName);
            this.Name = "CreateTableForm";
            this.Text = "Створення таблиці";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
