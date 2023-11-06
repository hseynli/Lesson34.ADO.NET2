using Microsoft.Data.SqlClient;
using System.Data;

/*
CREATE TABLE Employee
(
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50)
)

-- Create a stored procedure to insert a record and return the auto-incremented value
CREATE PROCEDURE InsertEmployee
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @InsertedID INT OUTPUT
AS
BEGIN
    INSERT INTO Employee (FirstName, LastName)
    VALUES (@FirstName, @LastName)
    
    -- Set the output parameter to the identity value of the inserted record
    SET @InsertedID = SCOPE_IDENTITY()
END
 */



string connectionString = "Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True"; 

using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();

    using (SqlCommand command = new SqlCommand("InsertEmployee", connection))
    {
        command.CommandType = CommandType.StoredProcedure;

        // Input parameters for the employee details
        command.Parameters.Add(new SqlParameter("@FirstName", "John"));
        command.Parameters.Add(new SqlParameter("@LastName", "Doe"));

        // Output parameter to capture the auto-incremented value
        SqlParameter insertedIDParam = new SqlParameter("@InsertedID", SqlDbType.Int);
        insertedIDParam.Direction = ParameterDirection.Output;
        command.Parameters.Add(insertedIDParam);

        command.ExecuteNonQuery(); // Execute the stored procedure

        // Retrieve the value of the output parameter
        int insertedID = Convert.ToInt32(insertedIDParam.Value);
        Console.WriteLine("Auto-incremented Employee ID: " + insertedID);
    }
}