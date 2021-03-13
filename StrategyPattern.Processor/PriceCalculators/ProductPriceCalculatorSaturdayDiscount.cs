using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Processor.PriceCalculators
{
    public class ProductPriceCalculatorSaturdayDiscount : IProductPriceCalculator
    {
        public double CalculateProductPrice(int quantity, double price)
        {
            return quantity * price * 0.9;
        }
    }
}
