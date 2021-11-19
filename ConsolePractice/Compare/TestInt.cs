using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolePractice.Compare
{
    public class TestInt
    {
        public static void Execute()
        {
            List<int> list = new List<int>() { 5, 1, 2, 6, 4, 0 };

            list.Sort();

            list.ForEach(e => Console.WriteLine(e.ToString()));
        }
    }
}
