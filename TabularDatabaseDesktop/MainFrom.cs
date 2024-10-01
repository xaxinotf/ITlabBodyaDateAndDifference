using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabularDatabaseDesktop
{
    public partial class MainForm : Form
    {
        private Database _database;
        private string _databaseFilePath = "database.json";

        public MainForm()
        {
            InitializeComponent();
            LoadDatabase();
            UpdateTableList();
        }

        private void LoadDatabase()
        {
            _database = Database.LoadFromFile(_databaseFilePath);
        }

        private void SaveDatabase()
        {
            _database.SaveToFile(_databaseFilePath);
        }

        private void UpdateTableList()
        {
            listBoxTables.Items.Clear();
            foreach (var table in _database.Tables)
            {
                listBoxTables.Items.Add(table.Name);
            }
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            var createTableForm = new CreateTableForm(_database);
            if (createTableForm.ShowDialog() == DialogResult.OK)
            {
                SaveDatabase();
                UpdateTableList();
            }
        }

        private void btnViewTable_Click(object sender, EventArgs e)
        {
            if (listBoxTables.SelectedItem != null)
            {
                string tableName = listBoxTables.SelectedItem.ToString();
                var table = _database.GetTable(tableName);
                var tableViewForm = new TableViewForm(table, _database);
                tableViewForm.ShowDialog();
                SaveDatabase();
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть таблицю.");
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            if (listBoxTables.SelectedItem != null)
            {
                string tableName = listBoxTables.SelectedItem.ToString();
                var result = MessageBox.Show($"Ви впевнені, що хочете видалити таблицю '{tableName}'?", "Підтвердження", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _database.DeleteTable(tableName);
                    SaveDatabase();
                    UpdateTableList();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть таблицю.");
            }
        }

        private void btnSaveDatabase_Click(object sender, EventArgs e)
        {
            SaveDatabase();
            MessageBox.Show("База даних збережена.");
        }

        private void btnLoadDatabase_Click(object sender, EventArgs e)
        {
            LoadDatabase();
            UpdateTableList();
            MessageBox.Show("База даних завантажена.");
        }
    }
}
