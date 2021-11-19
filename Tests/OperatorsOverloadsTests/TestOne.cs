using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.OperatorsOverloadsTests
{
    public class TestOne
    {
        [Fact]
        public void TestA()
        {
            var emp1 = new Employee() { Id = 1, Name = "John" };
            var emp2 = new Employee() { Id = 2, Name = "Tom" };

            var emp3 = emp1 + emp2;

            Assert.Equal(3, emp3.Id);
            Assert.Equal("John Tom", emp3.Name);
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Employee operator +(Employee a, Employee b)
        {
            return new Employee()
            {
                Id = a.Id + b.Id,
                Name = a.Name + " " + b.Name
            };
        }
    }
}
