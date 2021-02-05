using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Task<int> methodAClassA = ClassA.MethodAClassA();
            Task<int> methodBClassA = ClassA.MethodBClassA();
            int y = await methodBClassA;
            ClassC.MethodAClassC();
            int x = await methodAClassA;
            ClassC.MethodBClassC();
            ClassB.MethodAClassB(x);
        }
    }

    public class ClassA
    {
        public int PropInt { get; set; }
        public ClassB PropClassB { get; set; }
        public List<ClassC> ClassCs { get; set; }

        public static async Task<int> MethodAClassA()
        {
            Console.WriteLine("Start MethodAClassA()");
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"MethodAClassA {i}");
                    Thread.Sleep(1000);
                    count += 1;
                }
            });
            Console.WriteLine("Stop MethodAClassA()");
            return count;
        }

        public static async Task<int> MethodBClassA()
        {
            Console.WriteLine("Start MethodBClassA()");
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"MethodBClassA {i}");
                    Thread.Sleep(1000);
                    count += 1;
                }
            });
            Console.WriteLine("Stop MethodBClassA()");
            return count;
        }
    }

    public class ClassB
    {
        public string PropString { get; set; }

        public static void MethodAClassB(int x)
        {
            Console.WriteLine($"Output from MethodAClassA is {x}");
        }
    }

    public class ClassC
    {
        public EnumA PropEnumA { get; set; }

        public static void MethodAClassC()
        {
            Console.WriteLine("MethodAClassC");
        }

        public static void MethodBClassC()
        {
            Console.WriteLine("MethodBClassC");
        }
    }

    public enum EnumA 
    {
        Prop1,
        Prop2,
        Prop3
    }

}