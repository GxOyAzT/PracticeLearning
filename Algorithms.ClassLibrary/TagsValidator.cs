using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Algorithms.ClassLibrary
{
    public class TagsValidator
    {
        public bool validate(string tags)
        {
            if (tags == null)
                return true;

            if (tags == String.Empty)
                return true;

            if (tags[0] == ',')
                return false;

            if (tags[tags.Length - 1] == ',')
                return false;

            if (Regex.IsMatch(tags, "[ ]"))
                return false;

            if (Regex.IsMatch(tags, "[,]{2,}"))
                return false;

            return true;
        }
    }
}
