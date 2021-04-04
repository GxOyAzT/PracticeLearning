using System;
using System.Collections.Generic;
using System.Text;

namespace Wpf.DataAccess.Tables
{
    public abstract class ParentModel
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; private set; }

        public abstract void DeleteIncludes();
    }
}
