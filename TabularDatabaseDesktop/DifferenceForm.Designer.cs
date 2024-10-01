namespace TabularDatabaseDesktop
{
    partial class DifferenceForm
    {
        private System.Windows.Forms.ComboBox comboBoxTable1;
        private System.Windows.Forms.ComboBox comboBoxTable2;
        private System.Windows.Forms.TextBox txtResultTableName;
        private System.Windows.Forms.Button btnCalculateDifference;

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
            this.comboBoxTable1 = new System.Windows.Forms.ComboBox();
            this.comboBoxTable2 = new System.Windows.Forms.ComboBox();
            this.txtResultTableName = new System.Windows.Forms.TextBox();
            this.btnCalculateDifference = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // comboBoxTable1
            // 
            this.comboBoxTable1.FormattingEnabled = true;
            this.comboBoxTable1.Location = new System.Drawing.Point(100, 30);
            this.comboBoxTable1.Name = "comboBoxTable1";
            this.comboBoxTable1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTable1.TabIndex = 0;

            // 
            // comboBoxTable2
            // 
            this.comboBoxTable2.FormattingEnabled = true;
            this.comboBoxTable2.Location = new System.Drawing.Point(100, 60);
            this.comboBoxTable2.Name = "comboBoxTable2";
            this.comboBoxTable2.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTable2.TabIndex = 1;

            // 
            // txtResultTableName
            // 
            this.txtResultTableName.Location = new System.Drawing.Point(100, 90);
            this.txtResultTableName.Name = "txtResultTableName";
            this.txtResultTableName.Size = new System.Drawing.Size(121, 20);
            this.txtResultTableName.TabIndex = 2;

            // 
            // btnCalculateDifference
            // 
            this.btnCalculateDifference.Location = new System.Drawing.Point(100, 120);
            this.btnCalculateDifference.Name = "btnCalculateDifference";
            this.btnCalculateDifference.Size = new System.Drawing.Size(121, 23);
            this.btnCalculateDifference.TabIndex = 3;
            this.btnCalculateDifference.Text = "Розрахувати різницю";
            this.btnCalculateDifference.UseVisualStyleBackColor = true;
            this.btnCalculateDifference.Click += new System.EventHandler(this.btnCalculateDifference_Click);

            // 
            // DifferenceForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.btnCalculateDifference);
            this.Controls.Add(this.txtResultTableName);
            this.Controls.Add(this.comboBoxTable2);
            this.Controls.Add(this.comboBoxTable1);
            this.Name = "DifferenceForm";
            this.Text = "Difference Form";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
