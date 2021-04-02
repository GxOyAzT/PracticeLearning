using Auth.JwtIdentity.TenantDb.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Auth.JwtIdentity.TenantDb.Services
{
    public interface IContextOptionsBuilder
    {
        DbContextOptions<AppDbContext> CurrentContextOptions { get; }
    }
}
