using EmployeeManagement.Api.Tests.InitializeDatabase;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataModel;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagement.Api.Tests.EmployeeControllerTests
{
    [Collection("Sequential")]
    public class GetByIdTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GetByIdTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.WithWebHostBuilder(builder => 
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddDbContext<ApplicationDataContext>(options =>
                    {
                        options.UseSqlServer(GetTestDatabaseConnection.GetConnection());
                    });

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

                    services.AddAutoMapper(e => e.AddProfile<EmployeeProfile>());

                    services.AddControllers();
                });
            }).CreateClient();
        }

        [Fact]
        public async Task EmployeeGetByIdTestA()
        {
            var dataProcessor = new ResetDatabaseProcessor(new HardcodedDataV1());
            dataProcessor.Reset();

            var answer = await _client.GetAsync("/api1.1/employee/cbb00d49-c991-4964-86d4-92ff7c25a07b");

            answer.EnsureSuccessStatusCode();

            var employee = JsonConvert.DeserializeObject<EmployeeBasicDTO>(await answer.Content.ReadAsStringAsync());

            Assert.NotNull(employee);
            Assert.Equal("FullName A", employee.FullName);
        }

        [Fact]
        public async Task EmployeeGetByIdTestB()
        {
            var dataProcessor = new ResetDatabaseProcessor(new HardcodedDataV1());
            dataProcessor.Reset();

            var answer = await _client.GetAsync("/api1.1/employee/abc");

            Assert.Equal(HttpStatusCode.BadRequest, answer.StatusCode);

            var returnObject = JsonConvert.DeserializeObject<ErrorMessageDTO>(await answer.Content.ReadAsStringAsync());

            Assert.NotNull(returnObject);
            Assert.Equal(101, returnObject.InternalErrorCode);
            Assert.Equal("Cannot convert id", returnObject.ErrorMessage);
        }

        [Fact]
        public async Task EmployeeGetByIdTestC()
        {
            var dataProcessor = new ResetDatabaseProcessor(new HardcodedDataV1());
            dataProcessor.Reset();

            var answer = await _client.GetAsync("/api1.1/employee/00000000-0000-0000-0000-000000000000");

            Assert.Equal(HttpStatusCode.BadRequest, answer.StatusCode);

            var returnObject = JsonConvert.DeserializeObject<ErrorMessageDTO>(await answer.Content.ReadAsStringAsync());

            Assert.NotNull(returnObject);
            Assert.Equal(101, returnObject.InternalErrorCode);
            Assert.Equal("Cannot find user of id 00000000-0000-0000-0000-000000000000", returnObject.ErrorMessage);
        }
    }
}
