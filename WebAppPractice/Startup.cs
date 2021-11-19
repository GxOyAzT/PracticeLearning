using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAppPractice.HealthChecks;

namespace WebAppPractice
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlServer("Data Source=.;Initial Catalog=_FlashcardsAppTests;Integrated Security=True;"));

            //services.AddIdentity<IdentityUser, IdentityRole>(config =>
            //{
            //    config.Password.RequiredLength = 4;
            //    config.Password.RequireDigit = false;
            //    config.Password.RequireNonAlphanumeric = false;
            //    config.Password.RequireUppercase = false;
            //});

            //services.ConfigureApplicationCookie(config =>
            //{
            //    config.Cookie.Name = "Login.Cookie";
            //    config.LoginPath = "/Home/Login";
            //});

            services.AddMvc();

            services.AddHealthChecks().AddCheck<ExampleHealthCheck>("example_health_check")
                                      .AddCheck<SecondExampleHealthCheck>("second_example_health_check");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
