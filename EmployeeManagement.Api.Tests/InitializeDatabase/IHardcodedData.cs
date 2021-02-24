using EmployeeManagement.DataModel;
using System.Collections.Generic;

namespace EmployeeManagement.Api.Tests.InitializeDatabase
{
    public interface IHardcodedData
    {
        List<DepartmentModel> GetDepartments();
        List<EmployeeModel> GetEmployees();
    }
}