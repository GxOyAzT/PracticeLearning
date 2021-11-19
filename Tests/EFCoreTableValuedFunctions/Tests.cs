using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Tests.EFCoreTableValuedFunctions
{
    public class Tests
    {
        [Fact]
        public void TestA()
        {
            using (var db = new PracticeDbContext())
            {
                var tblAs = db.TblA.ToList();
            }
        }

        [Fact]
        public void TestB()
        {
            using (var db = new PracticeDbContext())
            {
                var sumValuesForOtherId = db.SumValuesForOtherId.ToList();
                Assert.Equal(9, sumValuesForOtherId.FirstOrDefault(e => e.SomeOtherId == 1).SumOfValuesForOtherId);
                Assert.Equal(14, sumValuesForOtherId.FirstOrDefault(e => e.SomeOtherId == 2).SumOfValuesForOtherId);
                Assert.Equal(6, sumValuesForOtherId.FirstOrDefault(e => e.SomeOtherId == 3).SumOfValuesForOtherId);
            }
        }

        [Fact]
        public void TestC()
        {
            using (var db = new PracticeDbContext())
            {
                var sumValuesForOtherId = db.TblA.ToList();
            }
        }
    }
}
