using System;

namespace EmployeeManagement.DataModel
{
    public class AddressBasicDTO
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public Guid EmployeeModelId { get; set; }
    }
}
