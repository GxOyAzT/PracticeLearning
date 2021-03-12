using EmployeeManagement.TestsMockData;
using Xunit;
using System.Linq;
using System;

namespace EmployeeManagement.DataAccess.Tests.EmployeeRepoTests
{
    [Collection("Sequential")]
    public class GetPagedTests
    {
        [Fact]
        public void GetPagedTestA()
        {
            InitializeDatabase(new HardcodedDataV2());

            IEmployeeRepo _employeeRepo = new EmployeeRepo(new ApplicationDataContextFactory());

            var ret = _employeeRepo.GetPaged(3, 2);

            Assert.Equal(3, ret.Count());
            Assert.NotNull(ret.FirstOrDefault(e => e.Id == Guid.Parse("b0b02cd9-0ef0-40ef-922d-5632ca76f25c")));
            Assert.NotNull(ret.FirstOrDefault(e => e.Id == Guid.Parse("76068C13-7491-4313-BC9C-88D993C05187")));
            Assert.NotNull(ret.FirstOrDefault(e => e.Id == Guid.Parse("51B0F8EE-17C2-4DB0-8665-902261AF9BFE")));
        }

        [Fact]
        public void GetPagedTestB()
        {
            InitializeDatabase(new HardcodedDataV2());

            IEmployeeRepo _employeeRepo = new EmployeeRepo(new ApplicationDataContextFactory());

            var ret = _employeeRepo.GetPaged(3, 3);

            Assert.Single(ret);
            Assert.NotNull(ret.FirstOrDefault(e => e.Id == Guid.Parse("CBB00D49-C991-4964-86D4-92FF7C25A07B")));
        }

        [Fact]
        public void GetPagedTestC()
        {
            InitializeDatabase(new HardcodedDataV2());

            IEmployeeRepo _employeeRepo = new EmployeeRepo(new ApplicationDataContextFactory());

            var ret = _employeeRepo.GetPaged(3, 1);

            Assert.Equal(3, ret.Count());
            Assert.NotNull(ret.FirstOrDefault(e => e.Id == Guid.Parse("0F85EE3B-BFCA-4D99-9229-0C1BDFF2FA8F")));
            Assert.NotNull(ret.FirstOrDefault(e => e.Id == Guid.Parse("9AF3F711-9150-428F-BC93-443361D7D912")));
            Assert.NotNull(ret.FirstOrDefault(e => e.Id == Guid.Parse("5DA83A01-D0C3-40B7-B886-4C26726882EF")));
        }

        static void InitializeDatabase(IHardcodedData hardcodedData)
        {
            ResetDatabaseProcessor resetDatabaseProcessor = new ResetDatabaseProcessor(hardcodedData, new ApplicationDataContextFactory().Build());
            resetDatabaseProcessor.Reset();
        }
    }
}
