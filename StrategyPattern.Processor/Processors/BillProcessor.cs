using StrategyPattern.Processor.Models;
using StrategyPattern.Processor.PriceCalculators;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Processor.Processors
{
    public class BillProcessor : IBillProcessor
    {
        private readonly IProductPriceCalculator _productPriceCalculator;

        public BillProcessor(IProductPriceCalculator productPriceCalculator)
        {
            _productPriceCalculator = productPriceCalculator;
        }

        List<ProductDbModel> ProductDbModels { get; set; }

        public double CalculateTotal()
        {
            double total = 0;

            foreach (var product in ProductDbModels)
                total += _productPriceCalculator.CalculateProductPrice(product.Quanitiy, product.Price);

            return total;
        }

        public void GetProducts(List<ProductDbModel> productDbModels) => 
            ProductDbModels = productDbModels;
    }
}
