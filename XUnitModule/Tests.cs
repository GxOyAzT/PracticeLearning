using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ConsoleUI;

namespace ConsoleUI
{
    public class Tests
    {
        [Fact]
        public void Test_GetAllFemales_Get()
        {
            IGetAllFemales getAllFemales = new GetAllFemales(new GetPeopleFromDb());

            Assert.Equal(3, (int)getAllFemales.Get().Count);
        }
    }
}
