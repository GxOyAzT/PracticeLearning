using EmployeeManagement.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.DataAccess
{
    public class AddressRepo : IAddressRepo
    {
        private readonly ApplicationDataContext _context;

        public AddressRepo(IApplicationDataContextFactory contextFactory)
        {
            _context = contextFactory.Build();
        }

        #region CRUD
        public List<AddressModel> Get()
        {
            return _context.AddressModels.ToList();
        }
        public AddressModel Get(Guid addressId)
        {
            return _context.AddressModels.FirstOrDefault(e => e.Id == addressId);
        }
        public void Insert(AddressModel addressModel)
        {
            _context.AddressModels.Add(addressModel);
            _context.SaveChanges();
        }
        public void Delete(AddressModel addressModel)
        {
            _context.AddressModels.Remove(addressModel);
            _context.SaveChanges();
        }
        #endregion

        public List<AddressModel> GetByEmployeeId(Guid employeeId)
        {
            return _context.AddressModels.Where(e => e.EmployeeModelId == employeeId).ToList();
        }
    }
}
