using StrategyPattern.Processor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Processor.Data
{
    public class ProductDbRepo
    {
        public ProductDbRepo()
        {
            Products = new List<ProductDbModel>();

            Products.Add(new ProductDbModel() { Id = 1, Name = "Product 1", Price = 58.99 });
            Products.Add(new ProductDbModel() { Id = 2, Name = "Product 2", Price = 11.99 });
            Products.Add(new ProductDbModel() { Id = 3, Name = "Product 3", Price = 199.99 });
        }

        public List<ProductDbModel> Products { get; set; }
    }
}
