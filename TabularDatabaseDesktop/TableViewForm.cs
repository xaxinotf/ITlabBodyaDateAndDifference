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
    public partial class TableViewForm : Form
    {
        private Table _table;
        private Database _database;

        public TableViewForm(Table table, Database database)
        {
            InitializeComponent();
            _table = table;
            _database = database;
            Text = $"Таблиця: {_table.Name}";
            LoadData();
        }

        private void LoadData()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            foreach (var field in _table.Fields)
            {
                dataGridView.Columns.Add(field.Name, $"{field.Name} ({field.Type})");
            }

            foreach (var row in _table.Rows)
            {
                var values = new object[_table.Fields.Count];
                for (int i = 0; i < _table.Fields.Count; i++)
                {
                    var fieldName = _table.Fields[i].Name;
                    values[i] = row.Values[fieldName];
                }
                dataGridView.Rows.Add(values);
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            var rowForm = new RowForm(_table);
            if (rowForm.ShowDialog() == DialogResult.OK)
            {
                _table.AddRow(rowForm.Row);
                LoadData();
            }
        }

        private void btnEditRow_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int index = dataGridView.SelectedRows[0].Index;
                var existingRow = _table.Rows[index];
                var rowForm = new RowForm(_table, existingRow);
                if (rowForm.ShowDialog() == DialogResult.OK)
                {
                    _table.UpdateRow(index, rowForm.Row);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть рядок.");
            }
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int index = dataGridView.SelectedRows[0].Index;
                var result = MessageBox.Show("Ви впевнені, що хочете видалити цей рядок?", "Підтвердження", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _table.DeleteRow(index);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть рядок.");
            }
        }

        private void btnDifference_Click(object sender, EventArgs e)
        {
            var differenceForm = new DifferenceForm(_database);
            if (differenceForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show($"Таблиця '{differenceForm.ResultTable.Name}' створена.");
            }
        }
    }
}
