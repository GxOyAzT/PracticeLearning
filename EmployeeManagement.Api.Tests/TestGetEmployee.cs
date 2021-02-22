using EmployeeManagement.DataModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagement.Api.Tests
{
    public class TestGetEmployee
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public TestGetEmployee()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<EmployeeManagement.Api.Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task TestA()
        {
            var response = await _client.GetAsync("/api1.1/employee");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestB()
        {
            var response = await _client.GetAsync("/api1.1/tests");
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal("Hello", responseString);
        }

        [Fact]
        public async Task TestC()
        {
            var response = await _client.GetAsync("/api1.1/tests");
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.NotEqual("111Hello", responseString);
        }
    }
}
