using EmployeeManagement.DataModel;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess
{
    public interface IEmployeeRepo
    {
        List<EmployeeModel> Get();
        EmployeeModel Get(Guid id);
        EmployeeModel Insert(EmployeeModel model);
        bool Delete(Guid id);
    }
}
