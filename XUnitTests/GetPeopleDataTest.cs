using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTests
{
    public class GetPeopleDataTest
    {
        [Fact]
        public void Test()
        {
            var db = new GetPeopleData();

            Assert.Throws<NotImplementedException>(() => db.Get());
        }
    }
}
