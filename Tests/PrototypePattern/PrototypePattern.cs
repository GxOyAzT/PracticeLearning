using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.PrototypePattern 
{
    public class Tests
    {
        [Fact]
        public void TestA()
        {
            Employee emp1 = new Employee()
            {
                Id = 101,
                Name = "Empp 1",
                Dob = DateTime.Now.Date,
                Department = new Department()
                {
                    Id = 11,
                    Name = "Dep 1"
                }
            };

            Employee emp2 = emp1.DeepClone();

            emp2.Id = 102;
            emp2.Department.Name = "Dep 2";

            Assert.Equal(101, emp1.Id);
            Assert.Equal("Dep 1", emp1.Department.Name);

            Assert.Equal(102, emp2.Id);
            Assert.Equal("Dep 2", emp2.Department.Name);
        }
    }

    internal interface IDeppClonable<T>
    {
        T DeepClone();
    }

    internal class Employee : IDeppClonable<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public Department Department { get; set; }

        public Employee DeepClone()
        {

            return new Employee()
            {
                Id = Id,
                Name = Name,
                Dob = Dob,
                Department = Department.DeepClone()
            };
        }
    }

    internal class Department : IDeppClonable<Department>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Department DeepClone()
        {
            return new Department()
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
