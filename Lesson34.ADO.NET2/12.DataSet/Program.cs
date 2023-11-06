using Microsoft.Data.SqlClient;
using System.Data;

DataSet ds = new DataSet();

string connectionString = @"Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True";
string commandString = "SELECT * FROM Person.Person; SELECT * FROM Person.PersonPhone";

SqlDataAdapter adapter = new SqlDataAdapter(commandString, connectionString);

adapter.Fill(ds); // DataAdapter köməkliyi ilə DataSet-i doldurmaq

// DataAdapter obyekti default olaraq cədvəlin sütunlarında heç bir məhdudiyyət yaratmır

Console.WriteLine(ds.Tables[0].TableName); // DataSet obyektinin birinci cədvəlinin adı nədir?
Console.WriteLine(ds.Tables[1].TableName); // DataSet obyektinin ikinci cədvəlinin adı nədir?

Console.WriteLine($"Row count={ds.Tables[0].Rows.Count}");
Console.WriteLine($"Row count={ds.Tables[1].Rows.Count}");