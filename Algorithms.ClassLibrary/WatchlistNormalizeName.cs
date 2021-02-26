using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.ClassLibrary
{
    public class WatchlistNormalizeName
    {
        public string Normalize(string input)
        {
            input = input.ToLower();
            input = input.Replace('ł', 'l');
            string output = System.Text.RegularExpressions.Regex.Replace(input.Normalize(NormalizationForm.FormD), "[^A-Za-z]", string.Empty);
            return output;
        }
    }
}
