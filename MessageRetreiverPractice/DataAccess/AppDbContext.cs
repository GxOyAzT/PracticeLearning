using MessageRetreiverPractice.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessageRetreiverPractice.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MessageModel> Messages { get; set; }
    }
}
