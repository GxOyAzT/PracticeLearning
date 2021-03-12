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
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using EmployeeManagement.Api.Data;

namespace EmployeeManagement.Api.Tests.EmployeeControllerTests
{
    [Collection("Sequential")]
    public class InsertTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public InsertTests(CustomWebApplicationFactory<EmployeeManagement.Api.Startup> factory)
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

            var inputModel = new EmployeeBasicDTO()
            {
                DateOfBirth = DateTime.Now.Date.AddDays(10),
                Salary = 5000,
                FullName = "FullName - 4",
                Gender = Gender.Female,
                DepartmentModelId = Guid.Parse("b1f13d06-7963-4b72-8103-56efb96c02dc")
            };

            var response = await _client.PostAsync("/api1.1/employee", new StringContent(JsonConvert.SerializeObject(inputModel), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var returnModel = JsonConvert.DeserializeObject<EmployeeBasicDTO>(await response.Content.ReadAsStringAsync());

            Assert.NotNull(returnModel);
            Assert.Equal("FullName - 4", returnModel.FullName);
            Assert.NotEqual(Guid.Empty, returnModel.Id);

            using (var db = new ApplicationDataContextFactoryTests().Build())
            {
                Assert.Equal(4, await db.EmployeeModels.CountAsync());
                Assert.NotNull(await db.EmployeeModels.FirstOrDefaultAsync(e => e.Id == returnModel.Id));
            }
        }

        [Fact]
        public async Task TestB()
        {
            var dataProcessor = new ResetDatabaseProcessor(new HardcodedDataV1(), new ApplicationDataContextFactoryTests().Build());
            dataProcessor.Reset();

            var inputModel = new EmployeeBasicDTO()
            {
                DateOfBirth = DateTime.Now.Date.AddDays(10),
                Salary = 5000,
                FullName = "",
                Gender = Gender.Female
            };

            var response = await _client.PostAsync("/api1.1/employee", new StringContent(JsonConvert.SerializeObject(inputModel), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var returnModel = JsonConvert.DeserializeObject<ErrorMessageDTO>(await response.Content.ReadAsStringAsync());

            Assert.NotNull(returnModel);
            Assert.Equal("FullName property cannot be null or empty", returnModel.ErrorMessage);
            Assert.Equal(201, returnModel.InternalErrorCode);

            using (var db = new ApplicationDataContextFactoryTests().Build())
            {
                Assert.Equal(3, await db.EmployeeModels.CountAsync());
            }
        }
    }
}
