using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.DataModel
{
    public class AddressModel
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }

        public Guid EmployeeModelId { get; set; }
        EmployeeModel EmployeeModel { get; set; }
    }
}
