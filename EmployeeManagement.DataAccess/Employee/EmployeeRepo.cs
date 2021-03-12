using EmployeeManagement.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.DataAccess
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ApplicationDataContext _context;

        public EmployeeRepo(IApplicationDataContextFactory contextFactory)
        {
            _context = contextFactory.Build();
        }

        #region CRUD
        public bool Delete(Guid id)
        {
            var empToRemove = _context.EmployeeModels.FirstOrDefault(e => e.Id == id);

            if (empToRemove == null)
                return false;

            _context.EmployeeModels.Remove(empToRemove);
            _context.SaveChanges();

            return true;
        }

        public List<EmployeeModel> Get()
        {
            return _context.EmployeeModels.ToList();
        }

        public EmployeeModel Get(Guid id)
        {
            return _context.EmployeeModels.FirstOrDefault(e => e.Id == id);
        }

        public EmployeeModel Insert(EmployeeModel model)
        {
            model.Id = Guid.Empty;

            _context.EmployeeModels.Add(model);
            _context.SaveChanges();

            return model;

        }

        public void Update(EmployeeModel employeeModel)
        {
            _context.EmployeeModels.Update(employeeModel);

            _context.SaveChanges();
        }
        #endregion

        public int Count()
        {
            return _context.EmployeeModels.Count();
        }

        public List<EmployeeModel> GetPaged(int count, int page)
        {
            return _context.EmployeeModels.Skip(count * (page - 1)).OrderBy(e => e.Id).Take(count).ToList();
        }
    }
}
