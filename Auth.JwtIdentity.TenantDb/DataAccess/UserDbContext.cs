using Auth.JwtIdentity.TenantDb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth.JwtIdentity.TenantDb.DataAccess
{
    public class UserDbContext : IdentityDbContext<AplicationUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
    }
}
