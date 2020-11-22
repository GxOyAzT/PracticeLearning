using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class PersonModel
    {
        public int Id { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PersonModel()
        {

        }

        public PersonModel(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
