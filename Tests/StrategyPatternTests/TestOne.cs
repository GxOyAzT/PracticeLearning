using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Tests.StrategyPatternTests
{
    public class TestOne
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public TestOne(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void TestA()
        {
            List<Employee> empList = new List<Employee>()
            {
                new Employee()
                {
                    Name = "Joe",
                },
                new Employee()
                {
                    Name = "Mark",
                },
                new Employee()
                {
                    Name = "Sofia",
                },
            };

            var displayDot = new DisplayEmployee<DisplayDot>(empList);
            _testOutputHelper.WriteLine(displayDot.Display());

            var displayComa = new DisplayEmployee<DisplayComa>(empList);
            _testOutputHelper.WriteLine(displayComa.Display());

            var displaySpace = new DisplayEmployee<DisplaySpace>(empList);
            _testOutputHelper.WriteLine(displaySpace.Display());
        }
    }

    public class DisplayEmployee<TDisplayEmployee> where TDisplayEmployee : IDisplayEmployee, new()
    {
        private readonly IDisplayEmployee displayEmployee;
        private readonly List<Employee> employees;

        public DisplayEmployee(List<Employee> employees)
        {
            this.displayEmployee = new TDisplayEmployee();
            this.employees = employees;
        }

        public string Display()
        {
            return displayEmployee.Display(employees);
        }
    }

    public interface IDisplayEmployee
    {
        public string Display(List<Employee> list);
    }

    public class DisplayDot : IDisplayEmployee
    {
        public string Display(List<Employee> list)
        {
            return list.SelectMany(e => e.Name).Aggregate("", (a, b) => a += $".{b}");
        }
    }

    public class DisplayComa : IDisplayEmployee
    {
        public string Display(List<Employee> list)
        {
            return list.SelectMany(e => e.Name).Aggregate("", (a, b) => a += $",{b}");
        }
    }

    public class DisplaySpace : IDisplayEmployee
    {
        public string Display(List<Employee> list)
        {
            return list.SelectMany(e => e.Name).Aggregate("", (a, b) => a += $" {b}");
        }
    }

    public class Employee
    {
        public string Name { get; set; }
    }
}
