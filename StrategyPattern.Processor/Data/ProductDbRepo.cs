using StrategyPattern.Processor.Models;
using System.Collections.Generic;

namespace StrategyPattern.Processor.Data
{
    public class ProductDbRepo
    {
        public ProductDbRepo()
        {
            Products = new List<ProductDbModel>();

            Products.Add(new ProductDbModel() { Id = 1, Name = "Product 1", Price = 58.99, Quanitiy = 1 });
            Products.Add(new ProductDbModel() { Id = 2, Name = "Product 2", Price = 11.99, Quanitiy = 1 });
            Products.Add(new ProductDbModel() { Id = 3, Name = "Product 3", Price = 199.99, Quanitiy = 1 });
        }

        public List<ProductDbModel> Products { get; set; }
    }
}
