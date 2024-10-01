using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TabularDatabaseDesktop
{
    public partial class CreateTableForm : Form
    {
        private Database _database;
        private List<Field> _fields = new List<Field>();

        public CreateTableForm(Database database)
        {
            InitializeComponent();
            _database = database;

            // Підпис підказок для вибору типу поля
            cmbDataType.DataSource = Enum.GetValues(typeof(DataType));
            lblDataTypeHint.Text = "Оберіть тип даних для нового поля.";

            // Додаткова підказка для користувача щодо порядку введення полів
            lblFieldNameHint.Text = "Введіть назву нового поля і натисніть 'Додати поле'.";
        }

        private void btnAddField_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFieldName.Text))
            {
                MessageBox.Show("Введіть назву поля.");
                return;
            }

            var fieldName = txtFieldName.Text;
            var dataType = (DataType)cmbDataType.SelectedItem;
            var field = new Field(fieldName, dataType);
            _fields.Add(field);

            listBoxFields.Items.Add($"{field.Name} ({field.Type})");
            lblFieldsCount.Text = $"Загальна кількість полів: {_fields.Count}";

            txtFieldName.Clear();
            cmbDataType.SelectedIndex = 0;
        }

        private void btnRemoveField_Click(object sender, EventArgs e)
        {
            if (listBoxFields.SelectedIndex >= 0)
            {
                _fields.RemoveAt(listBoxFields.SelectedIndex);
                listBoxFields.Items.RemoveAt(listBoxFields.SelectedIndex);
                lblFieldsCount.Text = $"Загальна кількість полів: {_fields.Count}";
            }
            else
            {
                MessageBox.Show("Оберіть поле для видалення.");
            }
        }

        private void btnEditField_Click(object sender, EventArgs e)
        {
            if (listBoxFields.SelectedIndex >= 0)
            {
                var selectedField = _fields[listBoxFields.SelectedIndex];
                txtFieldName.Text = selectedField.Name;
                cmbDataType.SelectedItem = selectedField.Type;
            }
            else
            {
                MessageBox.Show("Оберіть поле для редагування.");
            }
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTableName.Text))
            {
                MessageBox.Show("Введіть назву таблиці.");
                return;
            }

            if (_fields.Count == 0)
            {
                MessageBox.Show("Додайте хоча б одне поле.");
                return;
            }

            var table = new Table(txtTableName.Text);
            foreach (var field in _fields)
            {
                table.AddField(field);
            }

            try
            {
                _database.AddTable(table);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
