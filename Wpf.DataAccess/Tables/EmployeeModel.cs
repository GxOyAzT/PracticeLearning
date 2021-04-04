using System.Collections.Generic;

namespace Wpf.DataAccess.Tables
{
    public class EmployeeModel : ParentModel
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public virtual List<AddressModel> AddressModels { get; set; }

        public override void DeleteIncludes() => AddressModels = null;
    }
}
