using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.MongoDB.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
