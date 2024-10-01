using System;
using System.Collections.Generic;
using System.Linq;

namespace TabularDatabaseDesktop
{
    public class Table
    {
        public string Name { get; set; }
        public List<Field> Fields { get; set; }
        public List<Row> Rows { get; set; }

        public Table(string name)
        {
            Name = name;
            Fields = new List<Field>();
            Rows = new List<Row>();
        }

        public void AddField(Field field)
        {
            if (Fields.Exists(f => f.Name == field.Name))
                throw new Exception($"Поле з назвою '{field.Name}' вже існує.");
            Fields.Add(field);
        }

        public void AddRow(Row row)
        {
            ValidateRow(row);
            Rows.Add(row);
        }

        public void UpdateRow(int index, Row row)
        {
            ValidateRow(row);
            Rows[index] = row;
        }

        public void DeleteRow(int index)
        {
            Rows.RemoveAt(index);
        }

        public void ValidateRow(Row row)
        {
            foreach (var field in Fields)
            {
                if (!row.Values.ContainsKey(field.Name))
                    throw new Exception($"Поле '{field.Name}' відсутнє в рядку.");

                var value = row.Values[field.Name];
                if (!IsValidType(value, field.Type))
                    throw new Exception($"Значення поля '{field.Name}' має неправильний тип.");
            }
        }

        private bool IsValidType(object value, DataType type)
        {
            try
            {
                switch (type)
                {
                    case DataType.Integer:
                        Convert.ToInt32(value);
                        return true;
                    case DataType.Real:
                        Convert.ToDouble(value);
                        return true;
                    case DataType.Char:
                        return value is string s && s.Length == 1;
                    case DataType.String:
                        return value is string;
                    case DataType.Date:
                        DateTime.ParseExact(value.ToString(), "yyyy-MM-dd", null);
                        return true;
                    case DataType.DateInterval:
                        // Split on " - " to separate start and end dates
                        var dates = value.ToString().Split(new string[] { " - " }, StringSplitOptions.None);
                        if (dates.Length != 2)
                            return false;

                        // Parse start date
                        if (!DateTime.TryParseExact(dates[0].Trim(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime startDate))
                            return false;

                        // Parse end date
                        if (!DateTime.TryParseExact(dates[1].Trim(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime endDate))
                            return false;

                        // Ensure start date is earlier than or equal to end date
                        return startDate <= endDate;
                    default:
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
