using System;

namespace Practice.Attributes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var fieldInfos = typeof(Genre).GetFields();
        }
    }
}
