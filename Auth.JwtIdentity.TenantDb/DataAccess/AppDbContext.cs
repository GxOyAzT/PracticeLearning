using Auth.JwtIdentity.TenantDb.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.JwtIdentity.TenantDb.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<PersonModel> PersonModels { get; set; }
    }
}
