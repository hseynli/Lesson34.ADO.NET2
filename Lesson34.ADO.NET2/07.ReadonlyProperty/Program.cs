using System.Data;

DataTable table = new DataTable();

DataColumn column = table.Columns.Add("ReadonlyColumn", typeof(string));
column.ReadOnly = true;

DataRow newRow = table.NewRow();

newRow[0] = "ReadonlyValue";

table.Rows.Add(newRow);

Console.WriteLine(table.Rows[0][0]);

table.Rows[0][0] = "NewValue"; // Exception