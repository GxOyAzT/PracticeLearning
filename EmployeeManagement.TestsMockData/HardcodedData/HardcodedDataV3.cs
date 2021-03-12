using EmployeeManagement.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.TestsMockData
{
    public class HardcodedDataV3 : IHardcodedData
    {
        public List<EmployeeModel> EmployeeModels { get; set; }
        public List<DepartmentModel> Departments { get; set; }
        public List<AddressModel> AddressModels { get; set; }

        public HardcodedDataV3()
        {
            InitializeDepartments();
            InitializeEmployees();
            InitializeAddress();
        }

        void InitializeDepartments()
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
        }
        void InitializeEmployees()
        {
            EmployeeModels = new List<EmployeeModel>();

            EmployeeModels.Add(new EmployeeModel()
            {
                Id = Guid.Parse("cbb00d49-c991-4964-86d4-92ff7c25a07b"),
                Gender = Gender.Female,
                Salary = 5456.94,
                DateOfBirth = new DateTime(2000, 03, 01),
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

            EmployeeModels.Add(new EmployeeModel()
            {
                Id = Guid.Parse("5da83a01-d0c3-40b7-b886-4c26726882ef"),
                Gender = Gender.Male,
                Salary = 7000.00,
                DateOfBirth = new DateTime(1965, 12, 31),
                DepartmentModelId = Guid.Parse("e244600a-a289-40f8-976d-e4a5a6f91edd"),
                FullName = "FullName D"
            });

            EmployeeModels.Add(new EmployeeModel()
            {
                Id = Guid.Parse("76068c13-7491-4313-bc9c-88d993c05187"),
                Gender = Gender.Male,
                Salary = 7000.00,
                DateOfBirth = new DateTime(1980, 6, 14),
                DepartmentModelId = Guid.Parse("e244600a-a289-40f8-976d-e4a5a6f91edd"),
                FullName = "FullName E"
            });

            EmployeeModels.Add(new EmployeeModel()
            {
                Id = Guid.Parse("51b0f8ee-17c2-4db0-8665-902261af9bfe"),
                Gender = Gender.Female,
                Salary = 3000.00,
                DateOfBirth = new DateTime(2000, 05, 17),
                DepartmentModelId = Guid.Parse("e244600a-a289-40f8-976d-e4a5a6f91edd"),
                FullName = "FullName F"
            });

            EmployeeModels.Add(new EmployeeModel()
            {
                Id = Guid.Parse("0f85ee3b-bfca-4d99-9229-0c1bdff2fa8f"),
                Gender = Gender.Male,
                Salary = 4000.00,
                DateOfBirth = new DateTime(1993, 11, 17),
                DepartmentModelId = Guid.Parse("e244600a-a289-40f8-976d-e4a5a6f91edd"),
                FullName = "FullName G"
            });
        }
        void InitializeAddress()
        {
            AddressModels = new List<AddressModel>();

            AddressModels.Add(new AddressModel()
            {
                Id = Guid.Parse("f0366d53-5b79-4773-9344-436b6d5f6aaf"),
                City = "City-A-Employee-A",
                Street = "Street-A-Employee-A",
                ZipCode = "01-001",
                EmployeeModelId = Guid.Parse("cbb00d49-c991-4964-86d4-92ff7c25a07b") // Emp A
            });

            AddressModels.Add(new AddressModel()
            {
                Id = Guid.Parse("3ed6115b-b99b-49af-bdcd-72e72bf75b70"),
                City = "City-B-Employee-B",
                Street = "Street-B-Employee-B",
                ZipCode = "02-002",
                EmployeeModelId = Guid.Parse("9af3f711-9150-428f-bc93-443361d7d912") // Emp B
            });

            AddressModels.Add(new AddressModel()
            {
                Id = Guid.Parse("1b32aa81-cdc3-4fc9-b873-11e5359e2deb"),
                City = "City-C-Employee-B",
                Street = "Street-C-Employee-B",
                ZipCode = "03-002",
                EmployeeModelId = Guid.Parse("9af3f711-9150-428f-bc93-443361d7d912") // Emp B
            });

            AddressModels.Add(new AddressModel()
            {
                Id = Guid.Parse("177f10bd-5a6d-4688-a10d-4356ea0251b6"),
                City = "City-D-Employee-C",
                Street = "Street-D-Employee-C",
                ZipCode = "04-003",
                EmployeeModelId = Guid.Parse("b0b02cd9-0ef0-40ef-922d-5632ca76f25c") // Emp C
            });

            AddressModels.Add(new AddressModel()
            {
                Id = Guid.Parse("deabb4ef-03e5-443e-a5bf-d3cc603a00df"),
                City = "City-E-Employee-D",
                Street = "Street-E-Employee-D",
                ZipCode = "05-004",
                EmployeeModelId = Guid.Parse("5da83a01-d0c3-40b7-b886-4c26726882ef") // Emp D
            });

            AddressModels.Add(new AddressModel()
            {
                Id = Guid.Parse("a11850b9-bdac-432c-89b3-315ebd35600b"),
                City = "City-F-Employee-E",
                Street = "Street-F-Employee-E",
                ZipCode = "06-005",
                EmployeeModelId = Guid.Parse("76068c13-7491-4313-bc9c-88d993c05187") // Emp E
            });

            AddressModels.Add(new AddressModel()
            {
                Id = Guid.Parse("e8d1ef51-8f99-4cba-abc7-de81c48e8965"),
                City = "City-G-Employee-F",
                Street = "Street-G-Employee-F",
                ZipCode = "07-006",
                EmployeeModelId = Guid.Parse("51b0f8ee-17c2-4db0-8665-902261af9bfe") // Emp F
            });

            AddressModels.Add(new AddressModel()
            {
                Id = Guid.Parse("332e0092-6526-4f2e-aa87-16605f8e0c96"),
                City = "City-H-Employee-F",
                Street = "Street-H-Employee-F",
                ZipCode = "08-006",
                EmployeeModelId = Guid.Parse("51b0f8ee-17c2-4db0-8665-902261af9bfe") // Emp F
            });

            AddressModels.Add(new AddressModel()
            {
                Id = Guid.Parse("bb45e083-096d-4ee6-bc10-60a5e5e7a7fe"),
                City = "City-I-Employee-F",
                Street = "Street-I-Employee-F",
                ZipCode = "09-006",
                EmployeeModelId = Guid.Parse("51b0f8ee-17c2-4db0-8665-902261af9bfe") // Emp F
            });
        }

        public List<EmployeeModel> GetEmployees() => EmployeeModels;
        public List<DepartmentModel> GetDepartments() => Departments;
        public List<AddressModel> GetAddressModels() => AddressModels;
    }
}
