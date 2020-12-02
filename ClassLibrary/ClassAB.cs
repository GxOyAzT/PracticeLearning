using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class ClassAB : IInterfaceA, IInterfaceB
    {
        void IInterfaceA.Method()
        {
            Console.WriteLine("IInterfaceA.Method()");
        }

        void IInterfaceB.Method()
        {
            Console.WriteLine("IInterfaceB.Method()");
        }
    }
}
