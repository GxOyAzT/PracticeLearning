using EmployeeManagement.Api.Tests.Startup;
using EmployeeManagement.DataModel;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagement.Api.Tests
{
    public class TestGetEmployeeMethod2 : IClassFixture<WebApplicationFactory<MockStartup1>>
    {
        //private readonly WebApplicationFactory<MockStartup1> _factory;
        //private readonly HttpClient _client;

        //public TestGetEmployeeMethod2(WebApplicationFactory<MockStartup1> factory)
        //{
        //    _factory = factory.WithWebHostBuilder().Server<>;

        //    _client = _factory.CreateClient();
        //}

        //[Fact]
        //public async Task TestA()
        //{
        //    var response = await _client.GetAsync("/api1.1/employee");
        //    response.EnsureSuccessStatusCode();

        //    var employees = JsonSerializer.Deserialize<List<EmployeeBasicDTO>>(await response.Content.ReadAsStringAsync());

        //    Assert.Equal(5, employees.Count);
        //}
    }
}
