using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class BookModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public Guid AuthorId { get; set; }
        
        public AuthorModel AuthorModel { get; set; }
    }
}
