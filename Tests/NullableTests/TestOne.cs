using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

#nullable enable

namespace Tests.NullableTests
{
    public class TestOne
    {
        [Fact]
        public void TestA()
        {
            var emp = new Employee()
            {
                Id = 1,
                Name = "John",
                Department = new Department() { Id = 1 }
            };

            if (emp.Department == null)
            {

            }
            else
            {
                if (emp.Department.Name != null)
                {
                    Console.WriteLine(emp.Department!.Name.Trim(' '));
                }
            }
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public Department? Department { get; set; }

        public string GetEmployeeDescription() => $"Im {Name} and my department is {Department?.GetNameOfDeparemtnt()}";
    }

    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string GetNameOfDeparemtnt() => Name ?? "";
    }
}
