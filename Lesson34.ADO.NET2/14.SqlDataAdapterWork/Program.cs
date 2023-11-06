using Microsoft.Data.SqlClient;
using System.Data;

SqlConnection connection = new SqlConnection(@"Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True");

SqlDataAdapter adapter = new SqlDataAdapter("select * from Person.Person; select * from Person.PersonPhone", connection);
DataSet dataSet = new DataSet();
adapter.Fill(dataSet);
DataTable table1 = dataSet.Tables[0];
DataTable table2 = dataSet.Tables[1];

foreach (DataRow row in table2.Rows)
{
    foreach (DataColumn column in table2.Columns)
    {
        Console.WriteLine($"{column.ColumnName} : {row[column]}");
    }
    Console.WriteLine();
}

Console.ReadKey();