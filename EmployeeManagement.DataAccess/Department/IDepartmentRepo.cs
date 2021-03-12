using EmployeeManagement.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.DataAccess
{
    public interface IDepartmentRepo
    {
        List<DepartmentModel> Get();
    }
}
