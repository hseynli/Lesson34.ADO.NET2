using Microsoft.Data.SqlClient;
using System.Data;

//     CREATE proc dbo.GetNameById  @EmployeeID nvarchar(50)  
//       AS 
//      select * from Person.Person
//      WHERE BusinessEntityID = @EmployeeID 


string conStr = @"Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True"; // connection string
SqlConnection connection = new SqlConnection(conStr);

Console.WriteLine("Enter PersonId");
string name = Console.ReadLine(); // İstifadəçidən məlumatların alınması

SqlCommand cmd = new SqlCommand("GetNameById", connection);
cmd.CommandType = CommandType.StoredProcedure;

cmd.Parameters.AddWithValue("@EmployeeID", name); // Bir parametrin əldə olunması

connection.Open();

SqlDataReader reader = cmd.ExecuteReader(); // Komandanın icra olunması

while (reader.Read())
{
    for (int i = 0; i < reader.FieldCount; i++)
        Console.WriteLine("{0}: {1}", reader.GetName(i), reader[i]);

    Console.WriteLine();
}

connection.Close();

Console.ReadKey();