using EmployeeManagement.Api.Tests.InitializeDatabase;
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

namespace EmployeeManagement.Api.Tests.EmployeeControllerTests
{
    [Collection("Sequential")]
    public class InsertTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public InsertTests(CustomWebApplicationFactory<Startup> factory)
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
        public async Task TestA()
        {
            var dataProcessor = new ResetDatabaseProcessor(new HardcodedDataV1());
            dataProcessor.Reset();

            var inputModel = new EmployeeBasicDTO()
            {
                DateOfBirth = DateTime.Now.Date.AddDays(10),
                Salary = 5000,
                FullName = "FullName - 4",
                Gender = Gender.Female
            };

            var response = await _client.PostAsync("/api1.1/employee", new StringContent(JsonConvert.SerializeObject(inputModel), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var returnModel = JsonConvert.DeserializeObject<EmployeeBasicDTO>(await response.Content.ReadAsStringAsync());

            Assert.NotNull(returnModel);
            Assert.Equal("FullName - 4", returnModel.FullName);
            Assert.NotEqual(Guid.Empty, returnModel.Id);

            using (var db = new ApplicationDataContext())
            {
                Assert.Equal(4, await db.EmployeeModels.CountAsync());
                Assert.NotNull(await db.EmployeeModels.FirstOrDefaultAsync(e => e.Id == returnModel.Id));
            }
        }

        [Fact]
        public async Task TestB()
        {
            var dataProcessor = new ResetDatabaseProcessor(new HardcodedDataV1());
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

            using (var db = new ApplicationDataContext())
            {
                Assert.Equal(3, await db.EmployeeModels.CountAsync());
            }
        }
    }
}
