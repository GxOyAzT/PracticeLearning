using Practice.Yield.ConsoleApp.Speed;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice.Yield.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SomePractice.Execute();

            //Console.WriteLine("-- START --");

            //var people = DataAccess.GetPeopleYield();

            //foreach (var p in people)
            //{
            //    Console.WriteLine($"Read {p.FirstName} {p.LastName}");
            //}

            //var primeNumbers = Generators.GetPrimeNumbers().Take(10000);

            //foreach (var prime in primeNumbers)
            //{
            //    Console.WriteLine(prime);
            //}

            //Console.WriteLine("-- END --");
        }
    }

    public class Generators
    {
        public static IEnumerable<int> GetPrimeNumbers()
        {
            int counter = 1;

            while (true)
            {
                if (IsPrimeNumber(counter))
                {
                    yield return counter;
                }

                counter++;
            }
        }

        private static bool IsPrimeNumber(int value)
        {
            bool output = true;

            for (int i = 2; i < value / 2; i++)
            {
                if (value % i == 0)
                {
                    output = false;
                    break;
                }
            }

            return output;
        }
    }
}
