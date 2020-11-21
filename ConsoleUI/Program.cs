using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new[] { 0, 10, 20, 30, 40, 50 };

            int[] subNumbers = numbers[1..3];
        }
    }
}
