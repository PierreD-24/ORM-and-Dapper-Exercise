using System.Collections.Generic;

public interface IDepartmentRepository
{
    IEnumerable<Department> GetAllDepartments();

    void CreateDepartment(string name);
}
