using Microsoft.Data.SqlClient;

// Stored prosedurun kodu selectEmp:
//    CREATE proc dbo.GetPersonsTable 
//     as select * from Person.Person


string conStr = @"Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True"; // connection string
SqlConnection connection = new SqlConnection(conStr);

SqlCommand cmd = new SqlCommand("EXECUTE GetPersonsTable", connection);  
// GetPersonsTable adlı prosedurun çağırılması

connection.Open();

SqlDataReader reader = cmd.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine(reader.GetFieldValue<string>(4));
}

connection.Close();

Console.ReadKey();