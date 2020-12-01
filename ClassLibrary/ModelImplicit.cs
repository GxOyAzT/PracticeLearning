using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class ModelImplicit : IModel
    {
        public string xd { get; set; }

        public static implicit operator ModelImplicit(string XD)
        {
            return new ModelImplicit() { xd = XD };
        }
    }
}
