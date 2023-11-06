using Microsoft.Data.SqlClient;
using System.Data;

string connectionString = @"Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True";
string commandString = "SELECT * FROM Person.Person";

DataTable table = new DataTable();

SqlDataAdapter adapter = new SqlDataAdapter(commandString, connectionString);

int step = 2;

for (int i = 0; adapter.Fill(i, step, table) > 0; i += step)
{
    Console.WriteLine(table.Rows.Count);

    foreach (DataRow row in table.Rows)
    {
        foreach (DataColumn col in table.Columns)
            Console.WriteLine("{0} {1}", col.ColumnName, row[col]);

        Console.WriteLine();
    }

    Console.ReadKey();
    Console.Clear();
}