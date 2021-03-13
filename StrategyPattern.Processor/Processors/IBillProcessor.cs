using StrategyPattern.Processor.Models;
using StrategyPattern.Processor.PriceCalculators;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Processor.Processors
{
    public interface IBillProcessor
    {
        void GetProducts(List<ProductDbModel> productDbModels);
        double CalculateTotal();
        void SetCalculator(IProductPriceCalculator productPriceCalculator);
    }
}
