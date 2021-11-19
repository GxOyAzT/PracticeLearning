using System;
using System.Linq;

namespace Practice.Typeof.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = typeof(Person).Name;
            var assembly = typeof(Person).Assembly;

            var props = typeof(Person).GetProperties();

            var stringProps = props.Where(e => e.PropertyType == typeof(string)).ToList();

        }
    }

    
}
