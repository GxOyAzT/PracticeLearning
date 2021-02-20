using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.DataModel
{
    public class EmployeeBasicDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set;  }
        public DateTime DateOfBirth { get; set; }
        public double Salary { get; set; }
        public Gender Gender { get; set; }
    }
}
