using EmployeeManagement.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.DataAccess
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ApplicationDataContext _context;

        public DepartmentRepo(IApplicationDataContextFactory contextFacotry)
        {
            this._context = contextFacotry.Build();
        }
        public List<DepartmentModel> Get()
        {
            return _context.Departments.ToList();
        }
    }
}
