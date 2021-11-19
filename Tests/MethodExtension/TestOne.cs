using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.MethodExtension
{
    public class TestOne
    {
        [Fact]
        public void TestA()
        {
            var employee = new Employee() { Id = 1, Name = "John" };

            Assert.Equal("Hello I am John and my id numer is 1", employee.GetReadableInfo());
        }
    }

    public static class EmployeeExtension
    {
        public static string GetReadableInfo(this Employee emp)
        {
            return $"Hello I am {emp.Name} and my id numer is {emp.Id}";
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
