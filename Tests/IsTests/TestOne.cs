using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.IsTests
{
    public class TestOne
    {
        [Fact]
        public void TestA()
        {
            Employee employee = new Employee();

            object ob = employee;

            Assert.True(ob is Employee);
        }

        [Fact]
        public void TestB()
        {
            int a = 123;

            object obj = a;

            int b = (int)a;

            Assert.Equal(123, b);
        }

        [Fact]
        public void TestC()
        {
            int a = 123;

            object obj = a;

            float b = (float)a;

            Assert.Equal(123, b);
        }

        [Fact]
        public void TestD()
        {
            int a = 123;

            object obj = a;

            double b = (double)a;

            Assert.Equal(123, b);
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
