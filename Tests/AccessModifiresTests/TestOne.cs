using System;
using System.Collections.Generic;
using System.Text;
using Tests.NamespaceA;

namespace Tests.AccessModifiresTests
{
    class TestOne
    {
    }
}

namespace Tests.NamespaceA
{
    class ClassA 
    { 
        protected int MyProperty { get; set; }
        internal int MyPropertyInternal { get; set; }
    }
    class ClassB : ClassA { public int SomeMethod() => MyProperty; }
}

namespace Tests.NamespaceB
{
    class ClassC : ClassA 
    {
        public int SomeMethod() => MyProperty;
    }

    class ClassD : ClassA
    {
        public int SomeMethod() => MyPropertyInternal;
    }
}
