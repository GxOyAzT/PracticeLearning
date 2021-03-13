using StrategyPattern.Processor.Models;
using StrategyPattern.Processor.PriceCalculators;
using System.Collections.Generic;

namespace StrategyPattern.Processor.Processors
{
    public class BillProcessor : IBillProcessor
    {
        private IProductPriceCalculator _productPriceCalculator;

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

        public void SetCalculator(IProductPriceCalculator productPriceCalculator) => 
            _productPriceCalculator = productPriceCalculator;
    }
}
