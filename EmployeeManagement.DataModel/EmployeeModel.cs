using System;
using System.Collections.Generic;

namespace EmployeeManagement.DataModel
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Salary { get; set; }
        public Gender Gender { get; set; }

        public Guid DepartmentModelId { get; set; }
        public DepartmentModel DepartmentModel { get; set; }

        public List<AddressModel> AddressModels { get; set; }
    }
}
