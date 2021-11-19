using System;

namespace Practice.Yield.ConsoleApp
{
    public class PersonModel
    {
        public PersonModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Console.WriteLine($"Initialize Person  {FirstName} {LastName}");
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
