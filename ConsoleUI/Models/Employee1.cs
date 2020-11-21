using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsoleUI
{
    public class Employee1 : IEquatable<Employee1>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Equals([AllowNull] Employee1 other)
        {
            return Id == other.Id && this.Name == other.Name;
        }
    }
}
