using Microsoft.AspNetCore.Builder;

namespace CustomMiddleware.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomAuthorizationMiddleware(this IApplicationBuilder builder) =>
            builder.UseMiddleware<CustomAuthorizationMiddleware>();
    }
}
