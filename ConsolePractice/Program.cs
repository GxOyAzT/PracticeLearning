using ConsolePractice.Parallelism;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsolePractice
{
    class Program
    {
        static async Task Main()
        {
            ConsolePractice.BuilderPattern.BuilderEmailSenderExample.BuilderEmailSenderExample.Execute();
        }
    }

    public static class StringConsoleWriteline
    {
        public static void Write(this string str)
        {
            Console.WriteLine(str);
        }
    }

    public static class SomeClass
    {
        public static async Task SomeMethodAsync()
        {
            await Task.Delay(1000 * 2);
            Console.WriteLine("SomeMethodAsync()");
        }

        public static async Task SomeMethodExceptionAsync()
        {
            await Task.Delay(1000 * 2);
            Console.WriteLine("Gonna throw exception now.");
            throw new Exception();
        }

        public static void SomeMethod()
        {
            Thread.Sleep(1000 * 2);
            Console.WriteLine("SomeMethod()");
        }
    }

    public static class SomeClassTwo
    { 
        public static async Task SomeMethodA()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000 * 3);
                Console.WriteLine($"SomeMethodA() {i}");
            }
        }
    }
}
