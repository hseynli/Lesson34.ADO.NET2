using Microsoft.Data.SqlClient;
using System.Data;

string conStr = @"Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True"; // connection string
SqlConnection connection = new SqlConnection(conStr);

SqlCommand cmd = new SqlCommand("GetpersonsTable", connection);
cmd.CommandType = CommandType.StoredProcedure;  // Şərhə salmaq

connection.Open();

SqlDataReader reader = cmd.ExecuteReader();

while (reader.Read())
{
    for (int i = 0; i < reader.FieldCount; i++)
        Console.WriteLine("{0}: {1}", reader.GetName(i), reader[i]);

    Console.WriteLine();
}

connection.Close();

Console.ReadKey();