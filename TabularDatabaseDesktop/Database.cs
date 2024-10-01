using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace TabularDatabaseDesktop
{
    public class Database
    {
        public List<Table> Tables { get; set; }

        public Database()
        {
            Tables = new List<Table>();
        }

        public void AddTable(Table table)
        {
            if (Tables.Exists(t => t.Name == table.Name))
                throw new Exception($"Таблиця з назвою '{table.Name}' вже існує.");
            Tables.Add(table);
        }

        public void DeleteTable(string name)
        {
            var table = GetTable(name);
            if (table == null)
                throw new Exception($"Таблиця '{name}' не знайдена.");
            Tables.Remove(table);
        }

        public Table GetTable(string name)
        {
            return Tables.Find(t => t.Name == name);
        }

        public void SaveToFile(string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(this, options);
            File.WriteAllText(filePath, json);
        }

        public static Database LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return new Database();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Database>(json);
        }

        public Table Difference(string tableName1, string tableName2, string resultTableName)
        {
            var table1 = GetTable(tableName1);
            var table2 = GetTable(tableName2);

            if (table1 == null || table2 == null)
                throw new Exception("Одна з таблиць не знайдена.");

            if (!AreTableStructuresEqual(table1, table2))
                throw new Exception("Таблиці мають різну структуру.");

            var resultTable = new Table(resultTableName)
            {
                Fields = new List<Field>(table1.Fields)
            };

            foreach (var row1 in table1.Rows)
            {
                bool existsInTable2 = table2.Rows.Any(row2 => RowsAreEqual(row1, row2));
                if (!existsInTable2)
                    resultTable.Rows.Add(row1);
            }

            AddTable(resultTable);
            return resultTable;
        }

        private bool AreTableStructuresEqual(Table table1, Table table2)
        {
            if (table1.Fields.Count != table2.Fields.Count)
                return false;

            for (int i = 0; i < table1.Fields.Count; i++)
            {
                if (table1.Fields[i].Name != table2.Fields[i].Name ||
                    table1.Fields[i].Type != table2.Fields[i].Type)
                    return false;
            }
            return true;
        }

        private bool RowsAreEqual(Row row1, Row row2)
        {
            foreach (var field in row1.Values.Keys)
            {
                if (!row2.Values.ContainsKey(field) || !row2.Values[field].Equals(row1.Values[field]))
                    return false;
            }
            return true;
        }
    }
}
