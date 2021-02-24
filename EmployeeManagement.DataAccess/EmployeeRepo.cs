using EmployeeManagement.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.DataAccess
{
    public class EmployeeRepo : IEmployeeRepo
    {
        public bool Delete(Guid id)
        {
            using (var db = new ApplicationDataContext())
            {
                var empToRemove = db.EmployeeModels.FirstOrDefault(e => e.Id == id);

                if (empToRemove == null)
                    return false;

                db.EmployeeModels.Remove(empToRemove);
                db.SaveChanges();

                return true;
            }
        }

        public List<EmployeeModel> Get()
        {
            using (var db = new ApplicationDataContext())
                return db.EmployeeModels.ToList();
        }

        public EmployeeModel Get(Guid id)
        {
            using (var db = new ApplicationDataContext())
                return db.EmployeeModels.FirstOrDefault(e => e.Id == id);
        }

        public EmployeeModel Insert(EmployeeModel model)
        {
            using (var db = new ApplicationDataContext())
            {
                model.Id = Guid.Empty;

                db.EmployeeModels.Add(model);
                db.SaveChanges();

                return model;
            }
        }
    }
}
