using Auth.JwtIdentity.TenantDb.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace Auth.JwtIdentity.TenantDb.Services
{
    public class ContextOptionsBuilder : IContextOptionsBuilder
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public ContextOptionsBuilder(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public DbContextOptions<AppDbContext> CurrentContextOptions
        {
            get
            {
                var httpContext = _httpContextAccessor.HttpContext;

                if (httpContext == null)
                {
                    return null;
                }

                string tenantStr = httpContext.User.Claims.FirstOrDefault(e => e.Type == "db-id").Value;

                return new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlServer(
                        _configuration.GetConnectionString(tenantStr),
                        provideOptions => provideOptions.EnableRetryOnFailure())
                    .Options;
            }
        }
    }
}
