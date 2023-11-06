using Microsoft.Data.SqlClient;
using System.Data;

/*
CREATE PROCEDURE GetTotalPersonWithOutput
    @TotalOrders INT OUTPUT
AS
BEGIN
    -- Perform some logic to calculate the total orders
    SELECT @TotalOrders = COUNT(*) FROM Person.Person
END
 */

string connectionString = "Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True";

using SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

using SqlCommand command = new SqlCommand("GetTotalPersonWithOutput", connection);
command.CommandType = CommandType.StoredProcedure;

SqlParameter totalOrdersParam = new SqlParameter("@TotalOrders", SqlDbType.Int);
totalOrdersParam.Direction = ParameterDirection.Output;
command.Parameters.Add(totalOrdersParam);

command.ExecuteNonQuery(); // Execute the stored procedure

// Retrieve the value of the output parameter
int totalOrders = Convert.ToInt32(totalOrdersParam.Value);
Console.WriteLine("Total Person: " + totalOrders);