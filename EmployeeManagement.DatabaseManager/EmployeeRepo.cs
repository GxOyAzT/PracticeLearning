using EmployeeManagement.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.DatabaseManager
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private List<EmployeeModel> EmployeeModels { get; set; }

        public EmployeeRepo()
        {
            EmployeeModels = new List<EmployeeModel>();

            for (int i = 0; i< 10; i++)
            {
                EmployeeModels.Add(new EmployeeModel()
                {
                    Id = Guid.NewGuid(),
                    DateOfBirth = DateTime.Now.Date.AddDays(-(new Random()).Next(3000, 9000)),
                    Gender = (Gender)(new Random().Next(0,2)),
                    Salary = (new Random()).Next(2500,9000),
                    FullName = $"Employee-{i}"
                });
            }
        }

        public List<EmployeeModel> Get() => EmployeeModels;

        public void Insert(EmployeeModel model) => EmployeeModels.Add(model);

        public void Delete(Guid id)
        {
            var empToDelete = EmployeeModels.FirstOrDefault(e => e.Id == id);

            if (empToDelete != null)
            {
                EmployeeModels.Remove(empToDelete);
            }
        }
    }
}
