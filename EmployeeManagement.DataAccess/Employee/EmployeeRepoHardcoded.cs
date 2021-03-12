using EmployeeManagement.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.DataAccess
{
    public class EmployeeRepoHardcoded : IEmployeeRepo
    {
        public EmployeeRepoHardcoded()
        {
            EmployeeModels = new List<EmployeeModel>();

            for (int i = 0; i < 10; i++)
            {
                EmployeeModels.Add(new EmployeeModel()
                {
                    Id = Guid.NewGuid(),
                    DateOfBirth = DateTime.Now.Date.AddDays(-(new Random()).Next(3000, 9000)),
                    Gender = (Gender)(new Random().Next(0, 2)),
                    Salary = (new Random()).Next(2500, 9000),
                    FullName = $"Employee-{i}"
                });
            }
        }

        public List<EmployeeModel> EmployeeModels { get; private set; }

        public List<EmployeeModel> Get() => EmployeeModels;

        public EmployeeModel Insert(EmployeeModel model) { EmployeeModels.Add(model); return model; }

        public bool Delete(Guid id)
        {
            var empToDelete = EmployeeModels.FirstOrDefault(e => e.Id == id);

            if (empToDelete != null)
            {
                EmployeeModels.Remove(empToDelete);
            }

            return true;
        }

        public EmployeeModel Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public List<EmployeeModel> GetPaged(int count, int page)
        {
            throw new NotImplementedException();
        }

        public void Update(EmployeeModel model)
        {
            throw new NotImplementedException();
        }
    }
}
