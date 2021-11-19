using System;
using System.Collections.Generic;

namespace Practice.MongoDB.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime CreateionDate { get; set; }
        public CustomerModel User { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}
