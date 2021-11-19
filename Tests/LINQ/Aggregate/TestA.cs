using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Tests.LINQ.Aggregate
{
    public class TestA
    {
        public List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = 1,
                Name = "Name 1"
            },
            new Employee()
            {
                Id = 2,
                Name = "Name 2"
            },
            new Employee()
            {
                Id = 3,
                Name = "Name 3"
            }
        };

        [Fact]
        public void TestOne()
        {
            var aggregate = employees.Aggregate("", (a, b) => a += b.Name + ", ");

            Assert.Equal("Name 1, Name 2, Name 3, ", aggregate);
        }

        [Fact]
        public void TestTwo()
        {
            var aggregate = employees.Aggregate("", (a, b) => a += b.Name + ", ", e => e.Remove(e.Length - 2, 2));

            Assert.Equal("Name 1, Name 2, Name 3", aggregate);
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
