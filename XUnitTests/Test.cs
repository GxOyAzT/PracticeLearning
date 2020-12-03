using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTests
{
    public class Test
    {
        [Fact]
        public void Test_A()
        {
            ClassAB classAB = new ClassAB() { x = 10 };

            classAB.IncrementX(5);

            Assert.Equal(classAB.x, 15);
        }
    }
}
