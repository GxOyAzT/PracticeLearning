using System;

namespace Practice.Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            var element = new SomeProcessor<PersonModel>();

            element.DoSomething();
        }
    }
}
