using System;
using System.Collections.Generic;

namespace ClassLibrary.ManyToManyPractice
{
    public class AuthorModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<TrackModel> TrackModels { get; set; }
    }
}
