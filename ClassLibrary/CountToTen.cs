using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CountToTen : ICountToTen
    {
        public CountToTen(string methodName)
        {
            MethodName = methodName;
        }

        public string MethodName { get; }

        public Task Count(int separator)
        {
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{MethodName}: {i}");
                Thread.Sleep(separator);
            }

            return Task.CompletedTask;
        }
    }
}
