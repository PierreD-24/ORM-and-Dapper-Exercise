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
            // Build configuration to read from appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Get the connection string from the configuration
            string connString = config.GetConnectionString("DefaultConnection");

            // Create a new MySQL connection
            using IDbConnection conn = new MySqlConnection(connString);

            // Create an instance of DapperDepartmentRepository
            IDepartmentRepository departmentRepo = new DapperDepartmentRepository(conn);

            // Example: Get all departments
            var departments = departmentRepo.GetAllDepartments();
            foreach (var department in departments)
            {
                Console.WriteLine($"Id: {department.Id}, Name: {department.Name}");
            }

            // Example: Insert a new department
            var newDepartment = new Department { Name = "Human Resources" };
            departmentRepo.InsertDepartment(newDepartment);
            Console.WriteLine("New department inserted.");

                        // Create an instance of DapperProductRepository
            IProductRepository productRepo = new DapperProductRepository(conn);

            // Example: Retrieve all products and display them
            IEnumerable<Product> products = productRepo.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductID}, Name: {product.Name}, Price: {product.Price}, Category ID: {product.CategoryID}");
            }

            // Example: Create a new product
            productRepo.CreateProduct("New Product", 19.99, 1);
        }
    }
}


