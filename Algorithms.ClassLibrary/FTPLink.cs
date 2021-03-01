using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.ClassLibrary
{
    public class FTPLink
    {
        public string CutString(string url)
        {
            return url.Substring(0, ftpDir.LastIndexOf('\\'))
        }
    }
}
