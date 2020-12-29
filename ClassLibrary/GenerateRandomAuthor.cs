using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public class GenerateRandomAuthor
    {
        const string charsUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string charsLower = "abcdefghijklmnopqrstuvwxyz";

        public static AuthorModel Generate()
        {
            List<string> pseudos = new List<string>();

            for (int i = 0; i < (new Random()).Next(0,5); i++)
            {
                pseudos.Add(charsUpper[(new Random()).Next(0, charsUpper.Length - 1)] +
                new string(Enumerable.Repeat(charsLower, (new Random()).Next(5, 15)).Select(s => s[(new Random()).Next(s.Length)]).ToArray()));
            }

            AuthorModel output = new AuthorModel()
            {
                Id = Guid.NewGuid(),
                Dob = DateTime.Now.Date.AddDays(-(new Random()).Next(2500, 20000)),
                Name = charsUpper[(new Random()).Next(0, charsUpper.Length - 1)] +
                new string(Enumerable.Repeat(charsLower, (new Random()).Next(5, 15)).Select(s => s[(new Random()).Next(s.Length)]).ToArray()),
                Pseudonyms = pseudos.ToArray()
            };

            return output;
        }
    }
}
