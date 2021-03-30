using Microsoft.EntityFrameworkCore;
using SeveralDatabasesApproach.Models;

namespace SeveralDatabasesApproach.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }

        public DbSet<PersonModel> PersonModels { get; set; }
    }
}
