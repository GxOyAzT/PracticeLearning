using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Tests
{
    public class ApiWebApplicationFactory : WebApplicationFactory<EmployeeManagement.Api.Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            // will be called after the `ConfigureServices` from the Startup
            //builder.ConfigureTestServices(services =>
            //{
            //    services.AddTransient<IWeatherForecastConfigService, WeatherForecastConfigStub>();
            //});
        }
    }
}
