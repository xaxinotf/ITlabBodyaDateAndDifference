namespace TabularDatabaseDesktop
{
    partial class RowForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panelInputs;

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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panelInputs = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelHeader.Controls.Add(this.lblHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(500, 50);
            this.panelHeader.TabIndex = 0;

            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(10, 10);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(250, 25);
            this.lblHeader.Text = "Редагування рядка таблиці";
            this.lblHeader.TabIndex = 1;

            // 
            // panelInputs
            // 
            this.panelInputs.AutoScroll = true;
            this.panelInputs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInputs.Location = new System.Drawing.Point(10, 60);
            this.panelInputs.Name = "panelInputs";
            this.panelInputs.Size = new System.Drawing.Size(480, 300);
            this.panelInputs.TabIndex = 2;

            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(160, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Зберегти";
            this.btnSave.UseVisualStyleBackColor = false;

            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(280, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = false;

            // 
            // RowForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(500, 420);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panelInputs);
            this.Controls.Add(this.panelHeader);
            this.Name = "RowForm";
            this.Text = "Редагування рядка";

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
