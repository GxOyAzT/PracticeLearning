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
        public ApplicationDataContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeManagamentTests;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<EmployeeModel> EmployeeModels { get; set; }
        public DbSet<DepartmentModel> Deparemtnt { get; set; }
    }
}
