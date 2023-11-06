using System.Data;

DataTable table = new DataTable();

DataColumn column = table.Columns.Add("MaxLengthConstraintColumn", typeof(string));
column.MaxLength = 5;

DataRow newRow = table.NewRow();

newRow[0] = "Some value";

table.Rows.Add(newRow); // Exception

Console.WriteLine(table.Rows[0][0]);