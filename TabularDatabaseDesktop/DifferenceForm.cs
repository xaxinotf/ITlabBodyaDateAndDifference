using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TabularDatabaseDesktop
{
    public partial class DifferenceForm : Form
    {
        private Database _database;
        public Table ResultTable { get; private set; }

        public DifferenceForm(Database database)
        {
            InitializeComponent();
            _database = database;
            comboBoxTable1.DataSource = _database.Tables.Select(t => t.Name).ToList();
            comboBoxTable2.DataSource = _database.Tables.Select(t => t.Name).ToList();
        }

        private void btnCalculateDifference_Click(object sender, EventArgs e)
        {
            string tableName1 = comboBoxTable1.SelectedItem.ToString();
            string tableName2 = comboBoxTable2.SelectedItem.ToString();
            string resultTableName = txtResultTableName.Text;

            if (string.IsNullOrWhiteSpace(resultTableName))
            {
                MessageBox.Show("Введіть назву результуючої таблиці.");
                return;
            }

            try
            {
                // Викликаємо метод різниці таблиць і зберігаємо результат
                ResultTable = _database.Difference(tableName1, tableName2, resultTableName);

                // Виводимо повідомлення про успіх
                MessageBox.Show($"Таблиця '{ResultTable.Name}' успішно створена та збережена.");

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
