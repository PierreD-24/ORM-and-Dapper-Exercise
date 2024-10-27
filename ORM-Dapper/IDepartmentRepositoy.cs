using System.Collections.Generic;

public interface IDepartmentRepository
{
    IEnumerable<Department> GetAllDepartments(); // Method to get all departments
    void InsertDepartment(Department department); // Method to insert a new department
}
