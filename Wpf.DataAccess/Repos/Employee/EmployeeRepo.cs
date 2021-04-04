using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.DataAccess.DataAccess;
using Wpf.DataAccess.Tables;

namespace Wpf.DataAccess.Repos.Employee
{
    public class EmployeeRepo : BaseRepo<EmployeeModel>, IEmployeeRepo
    {
        public EmployeeRepo(ApplicationContext applicationContext) : base(applicationContext) { }
    }
}
