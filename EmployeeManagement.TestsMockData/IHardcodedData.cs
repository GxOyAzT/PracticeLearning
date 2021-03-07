using EmployeeManagement.DataModel;
using System.Collections.Generic;

namespace EmployeeManagement.TestsMockData
{
    public interface IHardcodedData
    {
        List<DepartmentModel> GetDepartments();
        List<EmployeeModel> GetEmployees();
    }
}