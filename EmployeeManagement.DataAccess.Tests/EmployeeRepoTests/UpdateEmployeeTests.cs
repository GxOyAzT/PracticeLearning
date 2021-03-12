using EmployeeManagement.DataModel;
using EmployeeManagement.TestsMockData;
using System;
using System.Linq;
using Xunit;

namespace EmployeeManagement.DataAccess.Tests.EmployeeRepoTests
{
    public class UpdateEmployeeTests
    {
        [Fact]
        public void UpdateTestA()
        {
            InitializeDatabase(new HardcodedDataV2());

            var emp = new EmployeeModel()
            {
                Id = Guid.Parse("b0b02cd9-0ef0-40ef-922d-5632ca76f25c"),
                Gender = Gender.Male,
                Salary = 1000.00,
                DateOfBirth = new DateTime(1965, 12, 31),
                DepartmentModelId = Guid.Parse("e244600a-a289-40f8-976d-e4a5a6f91edd"),
                FullName = "FullName Cc"
            };

            IEmployeeRepo _employeeRepo = new EmployeeRepo();

            _employeeRepo.Update(emp);

            using (var db = new ApplicationDataContext())
            {
                Assert.Equal(7, db.EmployeeModels.Count());
                var changedRecord = db.EmployeeModels.FirstOrDefault(e => e.Id == Guid.Parse("b0b02cd9-0ef0-40ef-922d-5632ca76f25c"));

                Assert.Equal(Gender.Male, changedRecord.Gender);
                Assert.Equal(1000.00, changedRecord.Salary);
                Assert.Equal(new DateTime(1965, 12, 31), changedRecord.DateOfBirth);
                Assert.Equal("FullName Cc", changedRecord.FullName);

            }
        }

        static void InitializeDatabase(IHardcodedData hardcodedData)
        {
            ResetDatabaseProcessor resetDatabaseProcessor = new ResetDatabaseProcessor(hardcodedData);
            resetDatabaseProcessor.Reset();
        }
    }
}
