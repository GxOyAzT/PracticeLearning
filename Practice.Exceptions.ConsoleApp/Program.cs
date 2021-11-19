using System;

namespace Practice.Exceptions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new SomeServiceA().SomeMethodInServiceA();
            }
            catch (Exception ex)
            {
                Console.WriteLine("-- MAIN --");
                Console.WriteLine(ex.StackTrace);
            }
        }
    }

    public class SomeServiceA
    {
        public void SomeMethodInServiceA()
        {
            try
            {
                new SomeServiceB().SomeMethodInServiceB();
            }
            catch (Exception ex)
            {
                Console.WriteLine("-- SomeMethodInServiceA --");
                Console.WriteLine(ex.StackTrace);
            }
        }
    }

    public class SomeServiceB
    {
        public void SomeMethodInServiceB()
        {
            throw new Exception();
        }
    }
}
