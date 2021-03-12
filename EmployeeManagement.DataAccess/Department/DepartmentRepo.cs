using EmployeeManagement.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.DataAccess
{
    public class DepartmentRepo : IDepartmentRepo
    {
        public List<DepartmentModel> Get()
        {
            using (var db = new ApplicationDataContext())
            {
                return db.Departments.ToList();
            }
        }
    }
}
