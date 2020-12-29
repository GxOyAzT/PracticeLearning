using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class GenerateRandomBook
    {
        const string charsUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string charsLower = "abcdefghijklmnopqrstuvwxyz";

        public static BookModel Generate(List<AuthorModel> authorModels)
        {
            BookModel bookModel = new BookModel()
            {
                Id = Guid.NewGuid(),
                Title = charsUpper[(new Random()).Next(0, charsUpper.Length - 1)] +
                new string(Enumerable.Repeat(charsLower, (new Random()).Next(5, 15)).Select(s => s[(new Random()).Next(s.Length)]).ToArray()),
                Pages = (new Random()).Next(10, 150) * 10,
                AuthorId = authorModels[(new Random()).Next(0, authorModels.Count() - 1)].Id
            };

            return bookModel;
        }
    }
}
