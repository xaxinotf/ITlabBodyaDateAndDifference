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
            var table1 = Tables.FirstOrDefault(t => t.Name == tableName1);
            var table2 = Tables.FirstOrDefault(t => t.Name == tableName2);

            if (table1 == null || table2 == null)
                throw new Exception("Одна з таблиць не знайдена.");

            if (table1.Fields.Count != table2.Fields.Count)
                throw new Exception("Таблиці мають різну кількість полів.");

            for (int i = 0; i < table1.Fields.Count; i++)
            {
                if (table1.Fields[i].Name != table2.Fields[i].Name || table1.Fields[i].Type != table2.Fields[i].Type)
                {
                    throw new Exception($"Поля з індексом {i} не збігаються за назвою або типом.");
                }
            }

            var resultTable = new Table(resultTableName);
            foreach (var field in table1.Fields)
            {
                resultTable.AddField(new Field(field.Name, field.Type));
            }

            foreach (var row1 in table1.Rows)
            {
                bool found = table2.Rows.Any(row2 => AreRowsEqual(row1, row2, table1.Fields));
                if (!found)
                {
                    resultTable.AddRow(row1);
                }
            }

            Tables.Add(resultTable);
            return resultTable;
        }



        // Допоміжний метод для перевірки можливості конвертації типів
        private bool CanConvertType(DataType type1, DataType type2)
        {
            // Дозволені конверсії: string <-> Date
            if ((type1 == DataType.String && type2 == DataType.Date) || (type1 == DataType.Date && type2 == DataType.String))
                return true;

            return false; // В інших випадках конвертація неможлива
        }
        private bool AreRowsEqual(Row row1, Row row2, List<Field> fields)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                var field = fields[i];
                object value1 = row1.Values[field.Name];
                object value2 = row2.Values[field.Name];

                // Перевірка значення типу Date і порівняння дати
                if (field.Type == DataType.Date)
                {
                    DateTime date1 = DateTime.Parse(value1.ToString());
                    DateTime date2 = DateTime.Parse(value2.ToString());

                    if (date1 != date2)
                        return false;
                }
                // Перевірка значення типу DateInterval і порівняння інтервалів
                else if (field.Type == DataType.DateInterval)
                {
                    var intervalParts1 = value1.ToString().Split('-');
                    var intervalParts2 = value2.ToString().Split('-');

                    if (intervalParts1.Length != 2 || intervalParts2.Length != 2)
                        return false;

                    DateTime start1 = DateTime.Parse(intervalParts1[0].Trim());
                    DateTime end1 = DateTime.Parse(intervalParts1[1].Trim());
                    DateTime start2 = DateTime.Parse(intervalParts2[0].Trim());
                    DateTime end2 = DateTime.Parse(intervalParts2[1].Trim());

                    if (start1 != start2 || end1 != end2)
                        return false;
                }
                else
                {
                    // Загальне порівняння для інших типів
                    if (!value1.Equals(value2))
                        return false;
                }
            }
            return true;
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
