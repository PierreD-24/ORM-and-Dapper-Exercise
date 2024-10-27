using System.Collections.Generic;
using System.Data;
using Dapper;

public class DapperDepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnection _dbConnection;

    public DapperDepartmentRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        string sql = "SELECT * FROM Departments"; // SQL query to get all departments
        return _dbConnection.Query<Department>(sql); // Executes the query and returns the result
    }

    public void InsertDepartment(Department department)
    {
        string sql = "INSERT INTO Departments (Name) VALUES (@Name)"; // SQL query to insert a new department
        _dbConnection.Execute(sql, new { Name = department.Name }); // Executes the insert command
    }
}
