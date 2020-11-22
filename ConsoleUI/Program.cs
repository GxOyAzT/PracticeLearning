using System;

/*
 Benefits of Records:
    - simple to set up
    - thread-safe (because it's immutable by default)
    - Easy/safe to share among methods

  When to use Records:
    - Capture external data that doesnt change
    - API calls
    - Processing data (ofc without change)

  When not to use Records:
    - when you need to change the data (Entity Framework)
 */

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Record1 r1a = new Record1("Tim", "Corey");
            Record1 r1b = new Record1("Tim", "Corey");
            Record1 r1c = new Record1("Sure", "Storm");

            Class1 c1a = new Class1("Tim", "Corey");
            Class1 c1b = new Class1("Tim", "Corey");
            Class1 c1c = new Class1("Sure", "Storm");

            #region Comparison CLASS vs RECORD
            Console.WriteLine("Record Type:");
            Console.WriteLine(r1a.ToString());
            Console.WriteLine($"Are these two objects equal: { Equals(r1a, r1b) }");
            Console.WriteLine($"Are these two objects reference equal: { ReferenceEquals(r1a, r1b) }");
            Console.WriteLine($"Are these two objects ==: { r1a == r1b }");
            // When we talking about record GetHashCode depends only on properties
            Console.WriteLine($"Hash code of A: { r1a.GetHashCode() }");
            Console.WriteLine($"Hash code of B: { r1b.GetHashCode() }");
            Console.WriteLine($"Hash code of C: { r1c.GetHashCode() }");

            Console.WriteLine();
            Console.WriteLine("**************  vs  **************");
            Console.WriteLine();

            Console.WriteLine("Class Type:");
            Console.WriteLine(c1a.ToString());
            Console.WriteLine($"Are these two objects equal: { Equals(c1a, c1b) }");
            Console.WriteLine($"Are these two objects reference equal: { ReferenceEquals(c1a, c1b) }");
            Console.WriteLine($"Are these two objects reference equal: {ReferenceEquals(c1a, c1b)}");
            // When we talking about class GetHashCode depends also on memory reference
            Console.WriteLine($"Hash code of A: { c1a.GetHashCode() }");
            Console.WriteLine($"Hash code of B: { c1b.GetHashCode() }");
            Console.WriteLine($"Hash code of C: { c1c.GetHashCode() }");
            #endregion

            Console.WriteLine();
            Console.WriteLine("*****************************************");
            Console.WriteLine();

            // deconstruct record based on the same pattern
            var (fn, ln) = r1a;
            Console.WriteLine($"{fn} {ln}");

            Record1 r1d = r1a with { FirstName = "John" };
            Console.WriteLine(r1d.ToString());

            Console.WriteLine();
            Console.WriteLine("*****************************************");
            Console.WriteLine();

            Record2 r2a = new Record2("Tim", "Corey");
            Console.WriteLine($"r2a: { r2a }");
            Console.WriteLine($"r2a.FullName: { r2a.FullName }");
            Console.WriteLine($"r2a fn: { r2a.FirstName }  ln: { r2a.LastName }");
            Console.WriteLine(r2a.SayHello());
        }
    }

    // Immutable - Values cannot be changed (by default) something like readonly class
    // It overrides ToString so it looks nice and give properties and assign values
    public record Record1 (string FirstName, string LastName);

    public record User1 (int Id, string FirstName, string LastName) : Record1(FirstName, LastName);

    public record Record2 (string FirstName, string LastName)
    {
        private string _firstName = FirstName;

        public string FirstName
        {
            get { return _firstName.Substring(0, 1); }
            init { }
        }

        public string FullName { get => $" {FirstName} {LastName} "; }

        public string SayHello()
        {
            return $"Hello {FirstName}";
        }
    }

    public class Class1
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public Class1(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void Deconstruct(out string FirstName, out string LastName)
        {
            FirstName = this.FirstName;
            LastName = this.LastName;
        }
    }
}