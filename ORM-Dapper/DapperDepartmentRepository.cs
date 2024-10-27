using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using Dapper;

public class DapperDepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnection _connection;

    public DapperDepartmentRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        return _connection.Query<Department>("SELECT * FROM Departments;");
    }

    public void CreateDepartment(string name)
    {
        _connection.Execute("INSERT INTO Departments (Name) Values (@name);", new { name });
    }
}