using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class AuthorModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string[] Pseudonyms { get; set; }

        public ICollection<BookModel> Books { get; set; }
    }
}
