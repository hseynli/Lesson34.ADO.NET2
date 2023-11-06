using Microsoft.Data.SqlClient;
using System.Data;

/*
CREATE PROCEDURE GetTotalPerson
AS
BEGIN
    DECLARE @TotalPerson INT
    SELECT @TotalPerson = COUNT(*) FROM Person.Person

    RETURN @TotalPerson
END
 */

string conStr = @"Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True"; // connection string

using SqlConnection connection = new SqlConnection(conStr);
connection.Open();

using SqlCommand command = new SqlCommand("GetTotalPerson", connection);
command.CommandType = CommandType.StoredProcedure;

SqlParameter returnValue = new SqlParameter();
returnValue.ParameterName = "@ReturnValue";
returnValue.Direction = ParameterDirection.ReturnValue;
command.Parameters.Add(returnValue);

command.ExecuteNonQuery();

int totalOrders = Convert.ToInt32(returnValue.Value);
Console.WriteLine("Total People: " + totalOrders);

Console.ReadKey();