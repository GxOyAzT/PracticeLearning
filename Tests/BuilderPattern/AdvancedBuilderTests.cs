using ConsolePractice.BuilderPatternAdvanced;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.BuilderPattern
{
    public class AdvancedBuilderTests
    {
        [Fact]
        public void TestA()
        {
            Employee employee = Employee.Create()
                .Base
                    .AddName("Frank")
                    .AddGender(Gender.Male)
                .Address
                    .AddCity("Poznań")
                    .AddStreet("Grunwaldzka")
                    .AddHouse(150)
                .Employment
                    .AddDepartment(Department.HR)
                    .AddSalary(5000m);

            Assert.Equal("Frank", employee.Name);
            Assert.Equal(Department.HR, employee.Department);
            Assert.Equal(Gender.Male, employee.Gender);
            Assert.Equal("Grunwaldzka", employee.Street);
        }
    }
}
