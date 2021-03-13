using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Processor.PriceCalculators
{
    public interface IProductPriceCalculator
    {
        double CalculateProductPrice(int quantity, double price);
    }
}
