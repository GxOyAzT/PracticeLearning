using EmployeeManagement.DataAccess;
using EmployeeManagement.DataModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeManagement.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Open",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                    });
            });

            services.AddSingleton<IEmployeeRepo, EmployeeRepo>();
            services.AddSingleton<IDepartmentRepo, DepartmentRepo>();
            services.AddSingleton<IAddressRepo, AddressRepo>();
            services.AddSingleton<IApplicationDataContextFactory, ApplicationDataContextFactory>();

            services.AddAutoMapper(e => e.AddProfile<EmployeeProfile>());
            services.AddAutoMapper(e => e.AddProfile<DepartmentProfile>());
            services.AddAutoMapper(e => e.AddProfile<AddressProfile>());

            services.AddControllers().AddNewtonsoftJson();
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Open");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
