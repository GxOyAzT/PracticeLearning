using Microsoft.EntityFrameworkCore;

namespace ClassLibrary
{
    public class LibraryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=Library;Username=postgres;Password=Truskawka1");

        public DbSet<AuthorModel> AuthorModels { get; set; }
        public DbSet<BookModel> BookModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorModel>(entity =>
            {
                entity.ToTable("authortbl");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Dob).HasColumnName("dob");
            });

            modelBuilder.Entity<BookModel>(entity =>
            {
                entity.ToTable("booktbl");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Pages).HasColumnName("pages");
                entity.Property(e => e.Title).HasColumnName("title");
                entity.Property(e => e.AuthorId).HasColumnName("authorid");

                entity.HasOne(e => e.AuthorModel)
                    .WithMany(d => d.Books)
                    .HasForeignKey(x => x.AuthorId);
            });
        }
    }
}
