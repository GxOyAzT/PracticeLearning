using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace CustomMiddleware.Middleware
{
    public class CustomAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public CustomAuthorizationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var authHeader = context.Request.Headers.ToList().FirstOrDefault(e => e.Key == "Authorize");

            if (authHeader.Value != "ABC123")
            {
                throw new SecurityException();
            }

            await _next(context);
        }
    }
}
