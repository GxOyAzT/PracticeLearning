using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.ManyToManyPractice
{
    public class ManyToManyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PracticeManyToMany;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<AuthorModel> AuthorModels { get; set; }
        public DbSet<TrackModel> TrackModels { get; set; }
    }
}
