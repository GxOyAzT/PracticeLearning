using EmployeeManagement.TestsMockData;
using System.Linq;
using Xunit;

namespace EmployeeManagement.DataAccess.Tests.DepartmentRepoTests
{
    public class GetTests
    {
        [Fact]
        public void GetTestA()
        {
            InitializeDatabase(new HardcodedDataV2());

            IDepartmentRepo _departmentRepo = new DepartmentRepo();

            var ret = _departmentRepo.Get();

            Assert.Equal(2, ret.Count());
        }

        static void InitializeDatabase(IHardcodedData hardcodedData)
        {
            ResetDatabaseProcessor resetDatabaseProcessor = new ResetDatabaseProcessor(hardcodedData);
            resetDatabaseProcessor.Reset();
        }
    }
}
