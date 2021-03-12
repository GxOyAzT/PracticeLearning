using EmployeeManagement.TestsMockData;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataModel;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using EmployeeManagement.Api.Data;

namespace EmployeeManagement.Api.Tests.EmployeeControllerTests
{
    [Collection("Sequential")]
    public class DeleteTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public DeleteTests(CustomWebApplicationFactory<Startup> factory)
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
        public async Task TestA()
        {
            var dataProcessor = new ResetDatabaseProcessor(new HardcodedDataV1(), new ApplicationDataContextFactoryTests().Build());
            dataProcessor.Reset();

            var response = await _client.DeleteAsync("/api1.1/employee/cbb00d49-c991-4964-86d4-92ff7c25a07b");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            using (var db = new ApplicationDataContextFactoryTests().Build())
            {
                Assert.Equal(2, await db.EmployeeModels.CountAsync());
                Assert.Null(await db.EmployeeModels.FirstOrDefaultAsync(e => e.Id == new Guid("cbb00d49-c991-4964-86d4-92ff7c25a07b")));
            }
        }

        [Fact]
        public async Task TestB()
        {
            var dataProcessor = new ResetDatabaseProcessor(new HardcodedDataV1(), new ApplicationDataContextFactoryTests().Build());
            dataProcessor.Reset();

            var response = await _client.DeleteAsync("/api1.1/employee/abc");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var returnObject = JsonConvert.DeserializeObject<ErrorMessageDTO>(await response.Content.ReadAsStringAsync());

            Assert.Equal("Incorret employee id format", returnObject.ErrorMessage);
            Assert.Equal(101, returnObject.InternalErrorCode);

            using (var db = new ApplicationDataContextFactoryTests().Build())
            {
                Assert.Equal(3, await db.EmployeeModels.CountAsync());
            }
        }

        [Fact]
        public async Task TestC()
        {
            var dataProcessor = new ResetDatabaseProcessor(new HardcodedDataV1(), new ApplicationDataContextFactory().Build());
            dataProcessor.Reset();

            var response = await _client.DeleteAsync("/api1.1/employee/00000000-0000-0000-0000-000000000000");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            var returnObject = JsonConvert.DeserializeObject<ErrorMessageDTO>(await response.Content.ReadAsStringAsync());

            Assert.Equal("Cannot find user of id 00000000-0000-0000-0000-000000000000", returnObject.ErrorMessage);
            Assert.Equal(101, returnObject.InternalErrorCode);

            using (var db = new ApplicationDataContextFactory().Build())
            {
                Assert.Equal(3, await db.EmployeeModels.CountAsync());
            }
        }
    }
}
