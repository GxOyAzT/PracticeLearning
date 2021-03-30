using Microsoft.EntityFrameworkCore;
using SeveralDatabasesApproach.Data;

namespace SeveralDatabasesApproach
{
    public interface IContextOptionsBuilder
    {
        DbContextOptions<AppDbContext> CurrentContextOptions { get; }
    }
}
