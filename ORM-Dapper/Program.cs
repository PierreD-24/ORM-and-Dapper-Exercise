using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var departmentRepo = new DapperDepartmentRepository(conn);

            Console.WriteLine("Departments:");
            IEnumerable<Department> departments = departmentRepo.GetAllDepartments();
            foreach (var department in departments)
            {
                Console.WriteLine($"ID: {department.Id}, Name: {department.Name}");
            }

            Console.WriteLine("\nEnter a new department name:");
            string newDepartmentName = Console.ReadLine();
            departmentRepo.CreateDepartment(newDepartmentName);

            Console.WriteLine("\nUpdated Departments:");
            departments = departmentRepo.GetAllDepartments();
            foreach (var department in departments)
            {
                Console.WriteLine($"ID: {department.Id}, Name: {department.Name}");
            }

            var productRepo = new DapperProductRepository(conn);


            Console.WriteLine("\nProducts:");
            IEnumerable<Product> products = productRepo.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductID}, Name: {product.Name}, Price: {product.Price}, CategoryID: {product.CategoryID}");
            }


            string newProductName = "New Product";
            double newProductPrice = 19.99;
            int newProductCategoryID = 1;
            productRepo.CreateProduct(newProductName, newProductPrice, newProductCategoryID);
            Console.WriteLine($"\nAdded product: {newProductName}");


            Console.WriteLine("\nUpdated Products:");
            products = productRepo.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductID}, Name: {product.Name}, Price: {product.Price}, CategoryID: {product.CategoryID}");
            }

            int productIdToUpdate = 885;
            var productToUpdate = new Product
            {
                ProductID = productIdToUpdate,
                Name = "Wii Sports Resort",
                Price = 29.99,
                CategoryID = 8
            };

            productRepo.UpdateProduct(productToUpdate);
            Console.WriteLine($"\nUpdated product ID: {productIdToUpdate}");


            Console.WriteLine("Database connection configured successfully.");
        }
    }
}


