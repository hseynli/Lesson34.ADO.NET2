using System.Data;

DataTable table = new DataTable();

DataColumn column = table.Columns.Add("UniqueColumn", typeof(string));
table.Columns.Add("UniqueColumn2", typeof(string));
column.Unique = true;

DataRow newRow = table.NewRow();
newRow[0] = "NonUniqueValue";
newRow[1] = "NonUniqueValuea";
table.Rows.Add(newRow);

newRow = table.NewRow();
newRow[0] = "NonUniqueValue2";
newRow[1] = "NonUniqueValueb";
table.Rows.Add(newRow);

newRow = table.NewRow();
newRow[0] = "NonUniqueValue3";
newRow[1] = "NonUniqueValuec";
table.Rows.Add(newRow);

Console.WriteLine(table.Rows[0][0]);
Console.WriteLine(table.Rows[1][0]);
Console.WriteLine(table.Rows[2][0]);

Console.WriteLine(table.Rows[0][1]);
Console.WriteLine(table.Rows[1][1]);
Console.WriteLine(table.Rows[2][1]);

Console.ReadKey();