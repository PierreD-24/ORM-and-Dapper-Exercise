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
        return _dbConnection.Query<Product>(sql);
    }

    public void CreateProduct(string name, double price, int categoryID)
    {
        string sql = "INSERT INTO Products (Name, Price, CategoryID) VALUES (@Name, @Price, @CategoryID)";
        _dbConnection.Execute(sql, new { Name = name, Price = price, CategoryID = categoryID });
    }

    public void UpdateProduct(Product product)
    {
        using var conn = _dbConnection;
        string sql = "UPDATE products SET Name = @Name, Price = @Price, CategoryID = @CategoryID WHERE ProductID = @ProductID";
        conn.Execute(sql, product);
    }

}


