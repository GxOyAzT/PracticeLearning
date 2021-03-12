using EmployeeManagement.Api.Data;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataModel;
using EmployeeManagement.TestsMockData;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagement.Api.Tests.DepartmentControllerTests
{
    [Collection("Sequential")]
    public class GetDepartmentTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GetDepartmentTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton<IApplicationDataContextFactory, ApplicationDataContextFactoryTests>();
                });
            }).CreateClient();
        }

        [Fact]
        public async Task GetDepartmentTestA()
        {
            InitializeDatabase(new HardcodedDataV2());

            var response = await _client.GetAsync("/api1.1/department");

            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            var objects = JsonConvert.DeserializeObject<List<DepartmentDTO>>(await response.Content.ReadAsStringAsync());

            Assert.Equal(2, objects.Count());
        }

        static void InitializeDatabase(IHardcodedData hardcodedData)
        {
            ResetDatabaseProcessor resetDatabaseProcessor = new ResetDatabaseProcessor(hardcodedData, new ApplicationDataContextFactoryTests().Build());
            resetDatabaseProcessor.Reset();
        }
    }
}