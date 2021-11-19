using ConsolePractice.BuilderPattern;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.BuilderPattern
{
    public class BuilderTests
    {
        [Fact]
        public void TestA()
        {
            Employee employee = Employee.Create().AddName("Frank").AddDepartment(Department.HR);

            Assert.Equal("Frank", employee.Name);
            Assert.Equal(Department.HR, employee.Department);
        }
    }
}
