using EmployeeManagement.DataAccess;
using System;

namespace EmployeeManagement.ConsoleHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployeeRepo employeeRepo = new EmployeeRepo();

            var ret = employeeRepo.GetPaged(3, 1);
        }
    }
}
