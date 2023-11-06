using Microsoft.Data.SqlClient;
using System.Data;

string connectionStr = @"Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True";

SqlConnection connection = new SqlConnection(connectionStr);
SqlCommand cmd = new SqlCommand("SELECT * FROM Person.Person", connection);

DataTable customers = new DataTable("People");

SqlDataAdapter adapter = new SqlDataAdapter(cmd); 

adapter.Fill(customers); // DataAdapter obyektinin Fill metodu cədvəli informasiya ilə doldurmağa imkan verir

foreach (DataRow row in customers.Rows)
{
    foreach (DataColumn column in customers.Columns)
    {
        Console.WriteLine("{0}: {1}", column.ColumnName, row[column]);
    }
    Console.WriteLine();
}

Console.ReadKey();