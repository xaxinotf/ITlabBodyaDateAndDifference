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

        public RowForm(Table table, Row existingRow = null)
        {
            InitializeComponent();
            _table = table;
            Row = existingRow ?? new Row();
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

                switch (field.Type)
                {
                    case DataType.Integer:
                        inputControl = new TextBox
                        {
                            Name = $"input_{field.Name}",
                            Width = 200,
                            Location = new System.Drawing.Point(180, yPosition)
                        };
                        break;
                    case DataType.Real:
                        inputControl = new TextBox
                        {
                            Name = $"input_{field.Name}",
                            Width = 200,
                            Location = new System.Drawing.Point(180, yPosition)
                        };
                        break;
                    case DataType.Char:
                        inputControl = new TextBox
                        {
                            Name = $"input_{field.Name}",
                            Width = 200,
                            Location = new System.Drawing.Point(180, yPosition),
                            MaxLength = 1
                        };
                        break;
                    case DataType.String:
                        inputControl = new TextBox
                        {
                            Name = $"input_{field.Name}",
                            Width = 200,
                            Location = new System.Drawing.Point(180, yPosition)
                        };
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
                        // Початок дати
                        Label startDateLabel = new Label
                        {
                            Text = $"{field.Name} Початок:",
                            Location = new System.Drawing.Point(10, yPosition),
                            AutoSize = true
                        };
                        panelInputs.Controls.Add(startDateLabel);

                        DateTimePicker startDatePicker = new DateTimePicker
                        {
                            Name = $"input_{field.Name}_Start",
                            Width = 200,
                            Location = new System.Drawing.Point(180, yPosition),
                            Format = DateTimePickerFormat.Short
                        };
                        panelInputs.Controls.Add(startDatePicker);

                        yPosition += 30;

                        // Кінець дати
                        Label endDateLabel = new Label
                        {
                            Text = $"{field.Name} Кінець:",
                            Location = new System.Drawing.Point(10, yPosition),
                            AutoSize = true
                        };
                        panelInputs.Controls.Add(endDateLabel);

                        DateTimePicker endDatePicker = new DateTimePicker
                        {
                            Name = $"input_{field.Name}_End",
                            Width = 200,
                            Location = new System.Drawing.Point(180, yPosition),
                            Format = DateTimePickerFormat.Short
                        };
                        panelInputs.Controls.Add(endDatePicker);

                        // Якщо є існуюче значення
                        if (Row.Values.ContainsKey(field.Name))
                        {
                            var interval = Row.Values[field.Name].ToString().Split(new string[] { " - " }, StringSplitOptions.None);
                            if (interval.Length == 2)
                            {
                                if (DateTime.TryParse(interval[0], out DateTime startDate))
                                    startDatePicker.Value = startDate;
                                if (DateTime.TryParse(interval[1], out DateTime endDate))
                                    endDatePicker.Value = endDate;
                            }
                        }

                        yPosition += 30;
                        continue; // Пропускаємо додавання контролів нижче
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

                panelInputs.Controls.Add(inputControl);
                yPosition += 30;
            }

            panelInputs.Height = yPosition;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var field in _table.Fields)
                {
                    object value = null;

                    switch (field.Type)
                    {
                        case DataType.Integer:
                            var intControl = panelInputs.Controls.Find($"input_{field.Name}", true).FirstOrDefault() as TextBox;
                            if (intControl == null)
                                throw new Exception($"Поле '{field.Name}' не знайдено.");
                            value = int.Parse(intControl.Text);
                            break;
                        case DataType.Real:
                            var realControl = panelInputs.Controls.Find($"input_{field.Name}", true).FirstOrDefault() as TextBox;
                            if (realControl == null)
                                throw new Exception($"Поле '{field.Name}' не знайдено.");
                            value = double.Parse(realControl.Text);
                            break;
                        case DataType.Char:
                            var charControl = panelInputs.Controls.Find($"input_{field.Name}", true).FirstOrDefault() as TextBox;
                            if (charControl == null)
                                throw new Exception($"Поле '{field.Name}' не знайдено.");
                            if (charControl.Text.Length != 1)
                                throw new Exception($"Поле '{field.Name}' має містити один символ.");
                            value = charControl.Text;
                            break;
                        case DataType.String:
                            var stringControl = panelInputs.Controls.Find($"input_{field.Name}", true).FirstOrDefault() as TextBox;
                            if (stringControl == null)
                                throw new Exception($"Поле '{field.Name}' не знайдено.");
                            value = stringControl.Text;
                            break;
                        case DataType.Date:
                            var dateControl = panelInputs.Controls.Find($"input_{field.Name}", true).FirstOrDefault() as DateTimePicker;
                            if (dateControl == null)
                                throw new Exception($"Поле '{field.Name}' не знайдено.");
                            value = dateControl.Value.ToString("yyyy-MM-dd");
                            break;
                        case DataType.DateInterval:
                            var startControl = panelInputs.Controls.Find($"input_{field.Name}_Start", true).FirstOrDefault() as DateTimePicker;
                            var endControl = panelInputs.Controls.Find($"input_{field.Name}_End", true).FirstOrDefault() as DateTimePicker;

                            if (startControl == null || endControl == null)
                                throw new Exception($"Поля для '{field.Name}' не знайдені.");

                            DateTime startDate = startControl.Value.Date;
                            DateTime endDate = endControl.Value.Date;

                            if (startDate > endDate)
                                throw new Exception($"Початкова дата не може бути пізніше кінцевої для поля '{field.Name}'.");

                            value = $"{startDate:yyyy-MM-dd} - {endDate:yyyy-MM-dd}";
                            break;
                    }

                    Row.Values[field.Name] = value;
                }

                _table.ValidateRow(Row);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
