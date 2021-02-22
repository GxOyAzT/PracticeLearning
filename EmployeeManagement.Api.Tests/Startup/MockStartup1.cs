using EmployeeManagement.DatabaseManager;
using EmployeeManagement.DataModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Api.Tests.Startup
{
    public class MockStartup1 : EmployeeManagement.Api.Startup
    {
        public MockStartup1(IConfiguration configuration) : base(configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("FirstPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://127.0.0.1:5500")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });

            services.AddSingleton<IEmployeeRepo, EmployeeRepoMockA>();

            services.AddAutoMapper(e => e.AddProfile<EmployeeProfile>());

            services.AddControllers();
        }



        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.Configure(app, env);
        }
    }
}
