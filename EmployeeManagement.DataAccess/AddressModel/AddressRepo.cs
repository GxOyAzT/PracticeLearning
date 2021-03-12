using EmployeeManagement.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.DataAccess
{
    public class AddressRepo : IAddressRepo
    {
        #region CRUD
        public List<AddressModel> Get()
        {
            using (var db = new ApplicationDataContext())
            {
                return db.AddressModels.ToList();
            }
        }
        public AddressModel Get(Guid addressId)
        {
            using (var db = new ApplicationDataContext())
            {
                return db.AddressModels.FirstOrDefault(e => e.Id == addressId);
            }
        }
        public void Insert(AddressModel addressModel)
        {
            using (var db = new ApplicationDataContext())
            {
                db.AddressModels.Add(addressModel);
                db.SaveChanges();
            }
        }
        public void Delete(AddressModel addressModel)
        {
            using (var db = new ApplicationDataContext())
            {
                db.AddressModels.Remove(addressModel);
                db.SaveChanges();
            }
        }
        #endregion

        public List<AddressModel> GetByEmployeeId(Guid employeeId)
        {
            using (var db = new ApplicationDataContext())
            {
                return db.AddressModels.Where(e => e.EmployeeModelId == employeeId).ToList();
            }
        }
    }
}
