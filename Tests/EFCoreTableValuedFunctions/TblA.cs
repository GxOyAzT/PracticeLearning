using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.EFCoreTableValuedFunctions
{
    public class TblA
    {
        public int Id { get; set; }
        public int SomeOtherId { get; set; }
        public int SomeValue { get; set; }
        public string ComputedValue { get; set; }
    }
}
