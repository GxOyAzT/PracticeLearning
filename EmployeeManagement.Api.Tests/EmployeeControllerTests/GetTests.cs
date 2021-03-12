﻿using EmployeeManagement.DataAccess;
using EmployeeManagement.DataModel;
using EmployeeManagement.TestsMockData;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using Newtonsoft.Json;
using EmployeeManagement.Api.Data;

namespace EmployeeManagement.Api.Tests.EmployeeControllerTests
{
    [Collection("Sequential")]
    public class GetTests : IClassFixture<CustomWebApplicationFactory<EmployeeManagement.Api.Startup>>
    {
        private readonly HttpClient _client;

        public GetTests(CustomWebApplicationFactory<EmployeeManagement.Api.Startup> factory)
        {
            _client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton<IApplicationDataContextFactory, ApplicationDataContextFactoryTests>();
                });
            }).CreateClient(new WebApplicationFactoryClientOptions());
        }

        [Fact]
        public async Task TestA()
        {
            var dataProcessor = new ResetDatabaseProcessor(new HardcodedDataV1(), new ApplicationDataContextFactoryTests().Build());
            dataProcessor.Reset();

            var response = await _client.GetAsync("/api1.1/employee");

            response.EnsureSuccessStatusCode();

            var employees = JsonConvert.DeserializeObject<List<EmployeeBasicDTO>>(await response.Content.ReadAsStringAsync());

            Assert.Equal(3, employees.Count);
            Assert.Contains("FullName A", employees.Select(e => e.FullName));
            Assert.Contains("FullName A", employees.Select(e => e.FullName));
        }
    }
}
