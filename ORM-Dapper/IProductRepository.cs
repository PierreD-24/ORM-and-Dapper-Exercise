using System.Collections.Generic;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();
    void CreateProduct(string name, double price, int categoryID);
}
