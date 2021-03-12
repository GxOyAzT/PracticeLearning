using EmployeeManagement.TestsMockData;
using System;
using System.Linq;
using Xunit;

namespace EmployeeManagement.DataAccess.Tests.AddressRepoTests
{
    [Collection("Sequential")]
    public class GetTests
    {
        [Fact]
        public void GetTestA()
        {
            InitializeDatabase(new HardcodedDataV3());

            var _addressRepo = new AddressRepo(new ApplicationDataContextFactory());

            var output = _addressRepo.Get();

            Assert.Equal(9, output.Count());
        }

        [Fact]
        public void GetTestB()
        {
            InitializeDatabase(new HardcodedDataV3());

            var _addressRepo = new AddressRepo(new ApplicationDataContextFactory());

            var output = _addressRepo.Get(Guid.Parse("BB45E083-096D-4EE6-BC10-60A5E5E7A7FE"));

            Assert.NotNull(output);
            Assert.Equal("City-I-Employee-F", output.City);
        }

        [Fact]
        public void GetTestC()
        {
            InitializeDatabase(new HardcodedDataV3());

            var _addressRepo = new AddressRepo(new ApplicationDataContextFactory());

            var output = _addressRepo.Get(Guid.Parse("00000000-096D-4EE6-BC10-60A5E5E7A7FE"));

            Assert.Null(output);
        }

        [Fact]
        public void GetTestD()
        {
            InitializeDatabase(new HardcodedDataV3());

            var _addressRepo = new AddressRepo(new ApplicationDataContextFactory());

            var output = _addressRepo.GetByEmployeeId(Guid.Parse("00000000-096D-4EE6-BC10-60A5E5E7A7FE"));

            Assert.Empty(output);
        }

        [Fact]
        public void GetTestE()
        {
            InitializeDatabase(new HardcodedDataV3());

            var _addressRepo = new AddressRepo(new ApplicationDataContextFactory());

            var output = _addressRepo.GetByEmployeeId(Guid.Parse("51b0f8ee-17c2-4db0-8665-902261af9bfe"));

            Assert.Equal(3, output.Count());
            Assert.NotNull(output.FirstOrDefault(e => e.Id == Guid.Parse("332e0092-6526-4f2e-aa87-16605f8e0c96")));
        }

        static void InitializeDatabase(IHardcodedData hardcodedData)
        {
            ResetDatabaseProcessor resetDatabaseProcessor = new ResetDatabaseProcessor(hardcodedData, new ApplicationDataContextFactory().Build());
            resetDatabaseProcessor.Reset();
        }
    }
}
