using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Tests.GenericsTests
{
    public class TestOne
    {
        [Fact]
        public void TestA()
        {
            Employee emp1 = new Employee()
            {
                Id = 1,
                Name = "Name1"
            };

            Employee emp2 = new Employee()
            {
                Id = 2,
                Name = "Name2"
            };

            Assert.True(emp1 == emp1);
            Assert.True(emp2 == emp2);
            Assert.False(emp1 == emp2);

            var comparer = new Comparer<Employee>(emp1);

            Assert.False(comparer.Compare(emp2));
            Assert.True(comparer.Compare(emp1));
        }
    }

    public class Employee : IEquatable<Employee>
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public bool Equals([AllowNull] Employee other)
        {
            return this.Id == other.Id;
        }
    }

    public class Comparer<T> where T : class
    {
        private readonly T obj;

        public Comparer(T obj)
        {
            this.obj = obj;
        }

        public bool Compare(T objTwo)
        {
            return obj == objTwo;
        }
    }
}
