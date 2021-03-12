using EmployeeManagement.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api
{
    public class ApplicationDataContextFactory : IApplicationDataContextFactory
    {
        public ApplicationDataContext Build()
        {
            return new ApplicationDataContext(new DbContextOptionsBuilder<ApplicationDataContext>().UseSqlServer(GetConnectionString()).Options);
        }

        private string GetConnectionString() => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeManagament;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
