using EmployeeManagement.DataModel;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataAccess
{
    public interface IAddressRepo
    {
        #region CRUD
        List<AddressModel> Get();
        AddressModel Get(Guid addressId);
        void Insert(AddressModel addressModel);
        void Delete(AddressModel addressModel);
        #endregion
        List<AddressModel> GetByEmployeeId(Guid employeeId);
    }
}
