using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsolePractice.PLINQ
{
    public static class PlinqA
    {
        public static List<Employee> Employees { get; set; } = new List<Employee>();

        public static void Execute()
        {
            for (int i = 1; i < 1000000; i++)
            {
                Employees.Add(new Employee() { Id = i, Name = RandomString(random.Next(5,25)) }); 
            }

            var milisecondsLINQ = 0l;

            for (int i = 0; i < 100; i++)
            {
                var sw = Stopwatch.StartNew();

                var linq = Employees.Where(e => e.Name.Contains('A') | e.Name.Contains('d')).ToList();

                sw.Stop();

                milisecondsLINQ += sw.ElapsedMilliseconds;
            }

            Console.WriteLine($"LINQ: {milisecondsLINQ / 10}");


            var milisecondsPLINQ = 0l;

            for (int i = 0; i < 100; i++)
            {
                var sw = Stopwatch.StartNew();

                var plinq = Employees.AsParallel().WithDegreeOfParallelism(8).AsUnordered().Where(e => e.Name.Contains('A') | e.Name.Contains('d')).ToList();

                sw.Stop();

                milisecondsPLINQ += sw.ElapsedMilliseconds;
            }

            Console.WriteLine($"PLINQ: {milisecondsPLINQ / 10}");
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnoprstuwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
