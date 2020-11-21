using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonModel person = new PersonModel();
            PersonModel nullPersonModel = null;

            Console.WriteLine(nullPersonModel?.GetType());
            Console.WriteLine(person?.GetType());
        }
    }
}
