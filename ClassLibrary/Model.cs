using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Model : IModel
    {
        public string xd { get; set; }

        public static explicit operator Model(string XD)
        {
            return new Model() { xd = XD };
        }
    }
}
