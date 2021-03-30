using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Generic
{
    public class SomeProcessor<TElement>
    {
        public void DoSomething()
        {
            Console.WriteLine(typeof(TElement));
        }
    }
}
