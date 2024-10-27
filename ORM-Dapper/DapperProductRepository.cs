using System.Collections.Generic;
using Dapper;
using System.Data;

public class DapperProductRepository : IProductRepository
{
    private readonly IDbConnection _dbConnection;

    public DapperProductRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        string sql = "SELECT * FROM Products"; 
        return _dbConnection.Query<Product>(sql); // Execute the query and map the results to Product objects
    }

    public void CreateProduct(string name, double price, int categoryID)
    {
        string sql = "INSERT INTO Products (Name, Price, CategoryID) VALUES (@Name, @Price, @CategoryID)"; // SQL to insert a new product
        _dbConnection.Execute(sql, new { Name = name, Price = price, CategoryID = categoryID }); // Execute the insertion
    }
}
