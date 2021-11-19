using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolePractice.LambdaExpressions
{
    public class TestOne
    {
        public static void Execute()
        {
            Action line = () => Console.WriteLine();

            Action<int> actionInt = e => Console.WriteLine(e.ToString());

            actionInt.Invoke(10);
        }
    }
}
