using System;
using System.Collections.Generic;

namespace WebAppPractice
{
    public class PracticeAspForListViewModel
    {
        public List<Employee> Employees { get; set; }
    }

    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Contract Contract { get; set; }
    }

    public enum Contract
    {
        B2B,
        Temporary,
        Intern
    }
}
