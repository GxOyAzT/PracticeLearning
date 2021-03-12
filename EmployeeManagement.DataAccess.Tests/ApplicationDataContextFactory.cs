using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DataAccess.Tests
{
    class ApplicationDataContextFactory : IApplicationDataContextFactory
    {
        public ApplicationDataContext Build()
        {
            return new ApplicationDataContext(new DbContextOptionsBuilder<ApplicationDataContext>().UseSqlServer(TestsDatabaseConnection.GetConnection()).Options);
        }
    }
}
