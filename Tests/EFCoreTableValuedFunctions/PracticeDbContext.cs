using Microsoft.EntityFrameworkCore;

namespace Tests.EFCoreTableValuedFunctions
{
    public class PracticeDbContext : DbContext
    {
        public PracticeDbContext(DbContextOptions options) : base(options)
        {
        }

        public PracticeDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PracticeLibrary;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SumValuesForOtherId>().HasNoKey().ToFunction("SumValuesForOtherId");

            modelBuilder.Entity<TblA>().Property(e => e.ComputedValue)
                .HasComputedColumnSql("'SomeOtherId: ' + cast(SomeOtherId as varchar(max)) + ' SomeValue: ' + cast(SomeValue as varchar(max))");

            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<TblA> TblA { get; set; }
        public DbSet<SumValuesForOtherId> SumValuesForOtherId { get; set; }
    }
}
