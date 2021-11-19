using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolePractice.BuilderPatternAdvanced
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }

        public Department Department { get; set; }
        public decimal Salary { get; set; }

        protected Employee() { }

        public static EmployeeBuilder Create()
        {
            return new EmployeeBuilder(new Employee());
        }
    }

    public class EmployeeBuilder
    {
        protected Employee Employee { get; set; }

        public EmployeeBuilder(Employee employee)
        {
            Employee = employee;
        }

        public EmployeeBuilderBase Base => new EmployeeBuilderBase(Employee);
        public EmployeeBuilderAddress Address => new EmployeeBuilderAddress(Employee);
        public EmployeeBuilderEmployment Employment => new EmployeeBuilderEmployment(Employee);

        public static implicit operator Employee(EmployeeBuilder employeeBuilder)
        {
            return employeeBuilder.Employee;
        }
    }

    public class EmployeeBuilderBase : EmployeeBuilder
    {
        public EmployeeBuilderBase(Employee employee) : base(employee)
        {
        }

        public EmployeeBuilderBase AddName(string name)
        {
            Employee.Name = name;
            return this;
        }

        public EmployeeBuilderBase AddGender(Gender gender)
        {
            Employee.Gender = gender;
            return this;
        }
    }

    public class EmployeeBuilderAddress : EmployeeBuilder
    {
        public EmployeeBuilderAddress(Employee employee) : base(employee)
        {
        }

        public EmployeeBuilderAddress AddCity(string city)
        {
            Employee.City = city;
            return this;
        }

        public EmployeeBuilderAddress AddStreet(string street)
        {
            Employee.Street = street;
            return this;
        }

        public EmployeeBuilderAddress AddHouse(int house)
        {
            Employee.House = house;
            return this;
        }
    }

    public class EmployeeBuilderEmployment : EmployeeBuilder
    {
        public EmployeeBuilderEmployment(Employee employee) : base (employee)
        {
        }

        public EmployeeBuilderEmployment AddDepartment(Department department)
        {
            Employee.Department = department;
            return this;
        }

        public EmployeeBuilderEmployment AddSalary(decimal salary)
        {
            Employee.Salary = salary;
            return this;
        }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum Department
    {
        HR,
        IT
    }
}
