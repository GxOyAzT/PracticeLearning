using EmployeeManagement.DataModel;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.DatabaseManager
{
    public interface IEmployeeRepo
    {
        List<EmployeeModel> Get();
        void Insert(EmployeeModel model);
        void Delete(Guid id);
    }
}
