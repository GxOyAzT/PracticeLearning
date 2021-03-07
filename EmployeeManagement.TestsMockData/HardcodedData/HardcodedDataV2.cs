using EmployeeManagement.DataModel;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.TestsMockData
{
    public class HardcodedDataV2 : IHardcodedData
    {
        public List<EmployeeModel> EmployeeModels { get; set; }
        public List<DepartmentModel> Departments { get; set; }

        public HardcodedDataV2()
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
                DepartmentId = Guid.Parse("b1f13d06-7963-4b72-8103-56efb96c02dc"),
                FullName = "FullName A"
            });

            EmployeeModels.Add(new EmployeeModel()
            {
                Id = Guid.Parse("9af3f711-9150-428f-bc93-443361d7d912"),
                Gender = Gender.Female,
                Salary = 2477.98,
                DateOfBirth = new DateTime(1998, 07, 20),
                DepartmentId = Guid.Parse("b1f13d06-7963-4b72-8103-56efb96c02dc"),
                FullName = "FullName B"
            });

            EmployeeModels.Add(new EmployeeModel()
            {
                Id = Guid.Parse("b0b02cd9-0ef0-40ef-922d-5632ca76f25c"),
                Gender = Gender.Male,
                Salary = 54631.00,
                DateOfBirth = new DateTime(1965, 12, 31),
                DepartmentId = Guid.Parse("e244600a-a289-40f8-976d-e4a5a6f91edd"),
                FullName = "FullName C"
            });

            EmployeeModels.Add(new EmployeeModel()
            {
                Id = Guid.Parse("5da83a01-d0c3-40b7-b886-4c26726882ef"),
                Gender = Gender.Male,
                Salary = 7000.00,
                DateOfBirth = new DateTime(1965, 12, 31),
                DepartmentId = Guid.Parse("e244600a-a289-40f8-976d-e4a5a6f91edd"),
                FullName = "FullName D"
            });

            EmployeeModels.Add(new EmployeeModel()
            {
                Id = Guid.Parse("76068c13-7491-4313-bc9c-88d993c05187"),
                Gender = Gender.Male,
                Salary = 7000.00,
                DateOfBirth = new DateTime(1980, 6, 14),
                DepartmentId = Guid.Parse("e244600a-a289-40f8-976d-e4a5a6f91edd"),
                FullName = "FullName E"
            });

            EmployeeModels.Add(new EmployeeModel()
            {
                Id = Guid.Parse("51b0f8ee-17c2-4db0-8665-902261af9bfe"),
                Gender = Gender.Female,
                Salary = 3000.00,
                DateOfBirth = new DateTime(2000, 05, 17),
                DepartmentId = Guid.Parse("e244600a-a289-40f8-976d-e4a5a6f91edd"),
                FullName = "FullName F"
            });

            EmployeeModels.Add(new EmployeeModel()
            {
                Id = Guid.Parse("0f85ee3b-bfca-4d99-9229-0c1bdff2fa8f"),
                Gender = Gender.Male,
                Salary = 4000.00,
                DateOfBirth = new DateTime(1993, 11, 17),
                DepartmentId = Guid.Parse("e244600a-a289-40f8-976d-e4a5a6f91edd"),
                FullName = "FullName G"
            });
        }

        public List<EmployeeModel> GetEmployees() => EmployeeModels;
        public List<DepartmentModel> GetDepartments() => Departments;
    }
}
