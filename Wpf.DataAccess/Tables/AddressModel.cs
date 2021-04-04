using System;

namespace Wpf.DataAccess.Tables
{
    public class AddressModel : ParentModel
    {
        public string Address { get; set; }

        public Guid EmployeeModelId { get; set; }
        public EmployeeModel EmployeeModel { get; set; }

        public override void DeleteIncludes() => EmployeeModel = null;
    }
}
