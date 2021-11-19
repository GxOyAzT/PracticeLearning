using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Tests.yield
{
    public class Tests
    {
        [Fact]
        public void TestA()
        {
            var ints = GetInts().ToList();

            Assert.Equal(2, ints.Count);
            Assert.Equal(1, ints.FirstOrDefault(e => e == 1));
            Assert.Equal(2, ints.FirstOrDefault(e => e == 2));
            Assert.Equal(0, ints.FirstOrDefault(e => e == 5));
        }

        public IEnumerable<int> GetInts()
        {
            yield return 1;

            yield return 2;
        }
    }
}
