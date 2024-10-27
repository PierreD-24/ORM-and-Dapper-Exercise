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
        }
    }
}


