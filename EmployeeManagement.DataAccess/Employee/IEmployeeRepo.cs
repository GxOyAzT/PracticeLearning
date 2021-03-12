using EmployeeManagement.DataModel;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess
{
    public interface IEmployeeRepo
    {
        #region CRUD
        List<EmployeeModel> Get();
        EmployeeModel Get(Guid id);
        EmployeeModel Insert(EmployeeModel model);
        bool Delete(Guid id);
        void Update(EmployeeModel model);
        #endregion
        int Count();
        List<EmployeeModel> GetPaged(int count, int page);
    }
}
