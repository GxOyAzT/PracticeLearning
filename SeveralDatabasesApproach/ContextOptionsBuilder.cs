using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SeveralDatabasesApproach.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeveralDatabasesApproach
{
    public class ContextOptionsBuilder: IContextOptionsBuilder
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

                string tenantStr = httpContext.Request.Headers["db-id"];

                return new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlServer(
                        _configuration.GetConnectionString(tenantStr),
                        provideOptions => provideOptions.EnableRetryOnFailure())
                    .Options;
            }
        }
    }
}
