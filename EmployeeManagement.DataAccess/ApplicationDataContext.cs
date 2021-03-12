using EmployeeManagement.DataModel;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DataAccess
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options)
        : base(options)
        {
        }

        public DbSet<EmployeeModel> EmployeeModels { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<AddressModel> AddressModels { get; set; }
    }
}
