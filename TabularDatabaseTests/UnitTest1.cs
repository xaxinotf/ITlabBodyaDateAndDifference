using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TabularDatabaseDesktop;

namespace TabularDatabaseTests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void TestCreateAndDeleteTable()
        {
            var database = new Database();
            var table = new Table("TestTable");
            database.AddTable(table);

            Assert.AreEqual(1, database.Tables.Count);
            Assert.AreEqual("TestTable", database.Tables[0].Name);

            database.DeleteTable("TestTable");
            Assert.AreEqual(0, database.Tables.Count);
        }

        [TestMethod]
        public void TestAddRowWithValidation()
        {
            var table = new Table("TestTable");
            table.AddField(new Field("Id", DataType.Integer));
            table.AddField(new Field("Name", DataType.String));

            var row = new Row();
            row.Values["Id"] = 1;
            row.Values["Name"] = "John Doe";
            table.AddRow(row);

            Assert.AreEqual(1, table.Rows.Count);

            // Testing validation with incorrect data type
            var invalidRow = new Row();
            invalidRow.Values["Id"] = "NotAnInteger";
            invalidRow.Values["Name"] = "Jane Doe";

            Assert.ThrowsException<Exception>(() => table.AddRow(invalidRow));
        }

        [TestMethod]
        public void TestDateTypeField()
        {
            var table = new Table("DateTable");
            table.AddField(new Field("EventDate", DataType.Date));

            var row = new Row();
            row.Values["EventDate"] = "2023-12-31"; // Correct date format
            table.AddRow(row);

            Assert.AreEqual(1, table.Rows.Count);
            Assert.AreEqual("2023-12-31", row.Values["EventDate"].ToString());
        }

        [TestMethod]
        public void TestDateIntervalTypeField()
        {
            var table = new Table("IntervalTable");
            table.AddField(new Field("DateRange", DataType.DateInterval));

            var row = new Row();
            row.Values["DateRange"] = "2023-01-01 - 2023-12-31"; // Correct date interval format
            table.AddRow(row);

            Assert.AreEqual(1, table.Rows.Count);
            Assert.AreEqual("2023-01-01 - 2023-12-31", row.Values["DateRange"].ToString());
        }

        [TestMethod]
        public void TestDifferenceOfTables()
        {
            var database = new Database();

            var table1 = new Table("Table1");
            table1.AddField(new Field("Id", DataType.Integer));
            table1.AddField(new Field("Name", DataType.String));
            var row1 = new Row();
            row1.Values["Id"] = 1;
            row1.Values["Name"] = "John Doe";
            table1.AddRow(row1);
            database.AddTable(table1);

            var table2 = new Table("Table2");
            table2.AddField(new Field("Id", DataType.Integer));
            table2.AddField(new Field("Name", DataType.String));
            var row2 = new Row();
            row2.Values["Id"] = 1;
            row2.Values["Name"] = "John Doe";
            table2.AddRow(row2);
            var row3 = new Row();
            row3.Values["Id"] = 2;
            row3.Values["Name"] = "Jane Doe";
            table2.AddRow(row3);
            database.AddTable(table2);

            var resultTable = database.Difference("Table2", "Table1", "ResultTable");

            Assert.AreEqual(1, resultTable.Rows.Count);
            Assert.AreEqual("Jane Doe", resultTable.Rows[0].Values["Name"]);
        }

        [TestMethod]
        public void TestDifferenceWithDateIntervalFields()
        {
            var database = new Database();

            var table1 = new Table("Table1");
            table1.AddField(new Field("Id", DataType.Integer));
            table1.AddField(new Field("DateRange", DataType.DateInterval));
            var row1 = new Row();
            row1.Values["Id"] = 1;
            row1.Values["DateRange"] = "2023-01-01 - 2023-06-30";
            table1.AddRow(row1);
            database.AddTable(table1);

            var table2 = new Table("Table2");
            table2.AddField(new Field("Id", DataType.Integer));
            table2.AddField(new Field("DateRange", DataType.DateInterval));
            var row2 = new Row();
            row2.Values["Id"] = 1;
            row2.Values["DateRange"] = "2023-01-01 - 2023-06-30";
            table2.AddRow(row2);
            var row3 = new Row();
            row3.Values["Id"] = 2;
            row3.Values["DateRange"] = "2023-07-01 - 2023-12-31";
            table2.AddRow(row3);
            database.AddTable(table2);

            var resultTable = database.Difference("Table2", "Table1", "ResultTableWithDateInterval");

            Assert.AreEqual(1, resultTable.Rows.Count);
            Assert.AreEqual("2023-07-01 - 2023-12-31", resultTable.Rows[0].Values["DateRange"]);
        }
    }
}
