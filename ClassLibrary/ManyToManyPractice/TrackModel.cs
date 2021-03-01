using System;
using System.Collections.Generic;

namespace ClassLibrary.ManyToManyPractice
{
    public class TrackModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public ICollection<AuthorModel> AuthorModels { get; set; }
    }
}
