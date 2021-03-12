using EmployeeManagement.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.DataAccess
{
    public class EmployeeRepo : IEmployeeRepo
    {
        #region CRUD
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

        public void Update(EmployeeModel employeeModel)
        {
            using (var db = new ApplicationDataContext())
            {
                db.EmployeeModels.Update(employeeModel);

                db.SaveChanges();
            }
        }
        #endregion

        public int Count()
        {
            using(var db = new ApplicationDataContext())
            {
                return db.EmployeeModels.Count();
            }
        }

        public List<EmployeeModel> GetPaged(int count, int page)
        {
            using (var db = new ApplicationDataContext())
            {
                return db.EmployeeModels.Skip(count * (page - 1)).OrderBy(e => e.Id).Take(count).ToList();
            }
        }
    }
}
