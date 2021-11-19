using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsolePractice.Parallelism
{
    public static class TestA
    {
        static List<Employee> employees = new List<Employee>();
        static List<Employee> employeesOver30s = new List<Employee>();
        static ConcurrentBag<Employee> employeesOver30sAsync = new ConcurrentBag<Employee>();
        static ConcurrentBag<Employee> employeesOver30sAsyncLocVar = new ConcurrentBag<Employee>();

        public static void Execute()
        {
            for (int i = 1; i <= 1000; i++)
            {
                employees.Add(new Employee() { Id = i, Dob = DateTime.Now.Date.AddDays((new Random()).Next(-18250, -6570)) });
            }

            var stopwatchSync = System.Diagnostics.Stopwatch.StartNew();

            foreach (var emp in employees)
            {
                if (emp.Dob <= DateTime.Now.Date.AddDays(-10950))
                {
                    employeesOver30s.Add(emp);
                    Thread.Sleep(1);
                }
            }

            stopwatchSync.Stop();

            Console.WriteLine($"Count: {employeesOver30s.Count()} in: {stopwatchSync.ElapsedMilliseconds} ms");

            var stopwatchAync = System.Diagnostics.Stopwatch.StartNew();

            Parallel.ForEach(employees, emp =>
            {
                if (emp.Dob <= DateTime.Now.Date.AddDays(-10950))
                {
                    employeesOver30sAsync.Add(emp);
                    Thread.Sleep(1);
                }
            });

            stopwatchAync.Stop();

            Console.WriteLine($"Count: {employeesOver30sAsync.Count()} in: {stopwatchAync.ElapsedMilliseconds} ms");



            var stopwatchAyncLocVar = System.Diagnostics.Stopwatch.StartNew();

            Parallel.ForEach<Employee, List<Employee>>(employees, () => new List<Employee>(), (emp, loop, subList) =>
            {
                if (emp.Dob <= DateTime.Now.Date.AddDays(-10950))
                {
                    subList.Add(emp);
                    Thread.Sleep(1);
                }
                return subList;
            },
            (empSublist) => empSublist.ForEach(e => employeesOver30sAsyncLocVar.Add(e)));

            stopwatchAyncLocVar.Stop();

            Console.WriteLine($"Count: {employeesOver30sAsync.Count()} in: {stopwatchAyncLocVar.ElapsedMilliseconds} ms");
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public DateTime Dob { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}  dob: {Dob.ToString("dd - MM - yyyy")}";
        }
    }
}
