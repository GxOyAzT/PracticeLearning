using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolePractice.BuilderPattern
{
    public class Builder
    {
        Employee Employee { get; set; }

        public Builder(Employee employee)
        {
            Employee = employee;
        }

        public static implicit operator Employee(Builder builder)
        {
            return builder.Employee;
        }

        public Builder AddName(string name)
        {
            Employee.Name = name;
            return this;
        }

        public Builder AddDepartment(Department department)
        {
            Employee.Department = department;
            return this;
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }

        protected Employee()
        {
        }

        public static Builder Create()
        {
            return new Builder(new Employee());
        }
    }

    public enum Department
    {
        HR,
        IT
    }
}
