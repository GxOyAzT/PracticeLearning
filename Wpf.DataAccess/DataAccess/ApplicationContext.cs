using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.DataAccess.Tables;

namespace Wpf.DataAccess.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<EmployeeModel> EmployeeModels { get; set; }
        public DbSet<AddressModel> AddressModels { get; set; }
    }
}
