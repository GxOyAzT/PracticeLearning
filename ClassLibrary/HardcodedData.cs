using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class HardcodedData
    {
        public static List<AuthorModel> GetAuthors()
        {
            return new List<AuthorModel>()
            {
                new AuthorModel()
                {
                    Id = Guid.Parse("bb227f80-ea3c-4a6a-8fc6-d19200b06d96"),
                    Name = "Author 1",
                    Dob = DateTime.Now.Date
                }
            };
        }

        public static List<BookModel> GetBooks()
        {
            return new List<BookModel>()
            {
                new BookModel()
                {
                    Id = Guid.Parse("d0284eb6-cb29-4f8b-bf18-4776e69cea24"),
                    Title = "Title 1",
                    Pages = 300,
                    AuthorId = Guid.Parse("bb227f80-ea3c-4a6a-8fc6-d19200b06d96")
                }
            };
        }
    }
}
