using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public static class ClassABExtend
    {
        public static void IncrementX (this ClassAB classAB, int n)
        {
            classAB.x += n;
        }
    }
}
