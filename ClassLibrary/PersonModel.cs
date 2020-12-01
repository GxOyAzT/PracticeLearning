using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class PersonModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }

        public PersonModel Clone()
        {
            return new PersonModel()
            {
                Id = Id,
                FullName = FullName,
                Age = Age
            };
        }
    }
}
