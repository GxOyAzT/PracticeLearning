using EmployeeManagement.DataModel;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.TestsMockData
{
    public class HardcodedDataV1 : IHardcodedData
    {
        public List<EmployeeModel> EmployeeModels { get; set; }
        public List<DepartmentModel> Departments { get; set; }

        public HardcodedDataV1()
        {
            Departments = new List<DepartmentModel>();

            Departments.Add(new DepartmentModel()
            {
                Id = Guid.Parse("b1f13d06-7963-4b72-8103-56efb96c02dc"),
                Name = "Department A"
            });

            Departments.Add(new DepartmentModel()
            {
                Id = Guid.Parse("e244600a-a289-40f8-976d-e4a5a6f91edd"),
                Name = "Department B"
            });

            EmployeeModels = new List<EmployeeModel>();

            EmployeeModels.Add(new EmployeeModel()
            {
                Id = Guid.Parse("cbb00d49-c991-4964-86d4-92ff7c25a07b"),
                Gender = Gender.Female,
                Salary = 5456.94,
                DateOfBirth = new DateTime(2000,03,01),
                DepartmentModelId = Guid.Parse("b1f13d06-7963-4b72-8103-56efb96c02dc"),
                FullName = "FullName A"
            });

            EmployeeModels.Add(new EmployeeModel()
            {
                Id = Guid.Parse("9af3f711-9150-428f-bc93-443361d7d912"),
                Gender = Gender.Female,
                Salary = 2477.98,
                DateOfBirth = new DateTime(1998, 07, 20),
                DepartmentModelId = Guid.Parse("b1f13d06-7963-4b72-8103-56efb96c02dc"),
                FullName = "FullName B"
            });

            EmployeeModels.Add(new EmployeeModel()
            {
                Id = Guid.Parse("b0b02cd9-0ef0-40ef-922d-5632ca76f25c"),
                Gender = Gender.Male,
                Salary = 54631.00,
                DateOfBirth = new DateTime(1965, 12, 31),
                DepartmentModelId = Guid.Parse("e244600a-a289-40f8-976d-e4a5a6f91edd"),
                FullName = "FullName C"
            });
        }

        public List<EmployeeModel> GetEmployees() => EmployeeModels;
        public List<DepartmentModel> GetDepartments() => Departments;

        public List<AddressModel> GetAddressModels() => new List<AddressModel>();
    }
}
