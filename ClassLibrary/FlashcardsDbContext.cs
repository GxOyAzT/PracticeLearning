using Microsoft.EntityFrameworkCore;
using Models;

namespace ClassLibrary
{
    public class FlashcardsDbContext : DbContext
    {
        public FlashcardsDbContext()
        {
        }

        public FlashcardsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConnectionString.GetConn());
            }
        }

        public DbSet<FlashcardDbModel> FlashcardsDbModels { get; set; }
        public DbSet<GroupDbModel> GroupDbModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupDbModel>(entity =>
            {
                entity.ToTable("GroupModelTbl", "fc");

                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<FlashcardDbModel>(entity =>
            {
                entity.ToTable("FlashcardModelTbl", "fc");

                entity.HasKey(e => new { e.Id, e.PracticeDirection });

                entity.HasOne(e => e.GroupDbModel)
                    .WithMany(d => d.FlashcardDbModels)
                    .HasForeignKey(x => x.GroupDbModelId);
            });
        }
    }
}
