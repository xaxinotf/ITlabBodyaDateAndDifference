using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TabularDatabaseDesktop
{
    public partial class RowForm : Form
    {
        private Table _table;
        public Row Row { get; private set; }

        public RowForm(Table table, Row existingRow = null)
        {
            InitializeComponent();
            _table = table;
            Row = existingRow ?? new Row();
            CreateControls();
        }

        private void CreateControls()
        {
            int yPosition = 10;
            foreach (var field in _table.Fields)
            {
                Label label = new Label();
                label.Text = $"{field.Name} ({field.Type})";
                label.Location = new System.Drawing.Point(10, yPosition);
                label.AutoSize = true;
                label.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
                this.Controls.Add(label);

                Control inputControl;
                switch (field.Type)
                {
                    case DataType.Integer:
                    case DataType.Real:
                    case DataType.Char:
                    case DataType.String:
                    case DataType.DateInterval:
                        inputControl = new TextBox();
                        inputControl.BackColor = System.Drawing.Color.White;
                        break;
                    case DataType.Date:
                        inputControl = new DateTimePicker();
                        break;
                    default:
                        inputControl = new TextBox();
                        inputControl.BackColor = System.Drawing.Color.White;
                        break;
                }

                inputControl.Name = $"input_{field.Name}";
                inputControl.Location = new System.Drawing.Point(180, yPosition);
                inputControl.Width = 250;

                if (Row.Values.ContainsKey(field.Name))
                {
                    if (inputControl is DateTimePicker dtp)
                    {
                        dtp.Value = DateTime.Parse(Row.Values[field.Name].ToString());
                    }
                    else
                    {
                        inputControl.Text = Row.Values[field.Name].ToString();
                    }
                }

                this.Controls.Add(inputControl);
                yPosition += 40;
            }

            btnSave.Location = new System.Drawing.Point(180, yPosition + 20);
            btnCancel.Location = new System.Drawing.Point(300, yPosition + 20);

            this.Height = yPosition + 100;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            foreach (var field in _table.Fields)
            {
                var control = this.Controls.Find($"input_{field.Name}", true)[0];
                object value = null;

                try
                {
                    switch (field.Type)
                    {
                        case DataType.Integer:
                            value = int.Parse(control.Text);
                            break;
                        case DataType.Real:
                            value = double.Parse(control.Text);
                            break;
                        case DataType.Char:
                            if (control.Text.Length != 1)
                                throw new Exception("Значення має бути одним символом.");
                            value = control.Text;
                            break;
                        case DataType.String:
                            value = control.Text;
                            break;
                        case DataType.Date:
                            value = ((DateTimePicker)control).Value.ToString("yyyy-MM-dd");
                            break;
                        case DataType.DateInterval:
                            value = control.Text;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Поле '{field.Name}': {ex.Message}");
                    return;
                }

                Row.Values[field.Name] = value;
            }

            try
            {
                _table.ValidateRow(Row);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
