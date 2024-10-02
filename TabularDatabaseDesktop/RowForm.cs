using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TabularDatabaseDesktop
{
    public partial class RowForm : Form
    {
        private Table _table;
        public Row Row { get; private set; }
        private Dictionary<string, string> _placeholders;

        public RowForm(Table table, Row existingRow = null)
        {
            InitializeComponent();
            _table = table;
            Row = existingRow ?? new Row();
            _placeholders = new Dictionary<string, string>();
            CreateControls();
        }

        private void CreateControls()
        {
            panelInputs.Controls.Clear();
            int yPosition = 10;

            foreach (var field in _table.Fields)
            {
                Label label = new Label
                {
                    Text = $"{field.Name} ({field.Type})",
                    Location = new System.Drawing.Point(10, yPosition),
                    AutoSize = true
                };
                panelInputs.Controls.Add(label);

                Control inputControl;
                string placeholder = string.Empty;

                switch (field.Type)
                {
                    case DataType.Integer:
                        inputControl = new TextBox
                        {
                            Name = $"input_{field.Name}",
                            Width = 200,
                            Location = new System.Drawing.Point(180, yPosition)
                        };
                        placeholder = "Введіть ціле число";
                        break;
                    case DataType.Real:
                        inputControl = new TextBox
                        {
                            Name = $"input_{field.Name}",
                            Width = 200,
                            Location = new System.Drawing.Point(180, yPosition)
                        };
                        placeholder = "Введіть дійсне число";
                        break;
                    case DataType.Char:
                        inputControl = new TextBox
                        {
                            Name = $"input_{field.Name}",
                            Width = 200,
                            Location = new System.Drawing.Point(180, yPosition),
                            MaxLength = 1
                        };
                        placeholder = "Введіть символ";
                        break;
                    case DataType.String:
                        inputControl = new TextBox
                        {
                            Name = $"input_{field.Name}",
                            Width = 200,
                            Location = new System.Drawing.Point(180, yPosition)
                        };
                        placeholder = "Введіть текст";
                        break;
                    case DataType.Date:
                        inputControl = new DateTimePicker
                        {
                            Name = $"input_{field.Name}",
                            Width = 200,
                            Location = new System.Drawing.Point(180, yPosition),
                            Format = DateTimePickerFormat.Short
                        };
                        break;
                    case DataType.DateInterval:
                        inputControl = new TextBox
                        {
                            Name = $"input_{field.Name}",
                            Width = 200,
                            Location = new System.Drawing.Point(180, yPosition)
                        };
                        placeholder = "yyyy-MM-dd - yyyy-MM-dd";
                        break;
                    default:
                        inputControl = new TextBox
                        {
                            Name = $"input_{field.Name}",
                            Width = 200,
                            Location = new System.Drawing.Point(180, yPosition)
                        };
                        break;
                }

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
                else if (inputControl is TextBox txt)
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                    _placeholders.Add(txt.Name, placeholder);
                }

                if (inputControl is TextBox textBox)
                {
                    textBox.Enter += RemovePlaceholder;
                    textBox.Leave += SetPlaceholder;
                }

                panelInputs.Controls.Add(inputControl);
                yPosition += 30;
            }

            panelInputs.Height = yPosition;
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (_placeholders.TryGetValue(textBox.Name, out var placeholder))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            }
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (sender is TextBox textBox && _placeholders.ContainsKey(textBox.Name) && textBox.Text == _placeholders[textBox.Name])
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = Color.Black;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (var field in _table.Fields)
            {
                var control = panelInputs.Controls.Find($"input_{field.Name}", true).FirstOrDefault();
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
                            var intervalParts = control.Text.Split('-');
                            if (intervalParts.Length != 2)
                                throw new Exception("Інтервал дати має бути у форматі 'yyyy-MM-dd - yyyy-MM-dd'");
                            DateTime.Parse(intervalParts[0].Trim());
                            DateTime.Parse(intervalParts[1].Trim());
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
