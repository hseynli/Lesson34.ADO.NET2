using System.Data;

DataTable table = new DataTable();

DataColumn column = table.Columns.Add("AllowDBNullColumn", typeof(int));
column.AllowDBNull = false;

DataRow newRow = table.NewRow();

newRow[0] = DBNull.Value;

table.Rows.Add(newRow); // Exception

Console.WriteLine(table.Rows[0][0]);