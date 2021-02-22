using EmployeeManagement.DatabaseManager;
using EmployeeManagement.DataModel;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagement.Api.Tests
{
    public class TestDocs : IClassFixture<CustomWebApplicationFactory<EmployeeManagement.Api.Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<EmployeeManagement.Api.Startup>
            _factory;

        public TestDocs(
            CustomWebApplicationFactory<EmployeeManagement.Api.Startup> factory)
        {
            _factory = factory;
            _client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<IEmployeeRepo, EmployeeRepoMockA>();
                });
            }).CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task Post_DeleteAllMessagesHandler_ReturnsRedirectToRoot()
        {
            var response = await _client.GetAsync("/api1.1/employee");
            response.EnsureSuccessStatusCode();

            var employees = JsonSerializer.Deserialize<List<EmployeeBasicDTO>>(await response.Content.ReadAsStringAsync());

            Assert.Equal(5, employees.Count);
        }
    }
}