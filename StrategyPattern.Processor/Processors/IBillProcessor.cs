using StrategyPattern.Processor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Processor.Processors
{
    public interface IBillProcessor
    {
        void GetProducts(List<ProductDbModel> productDbModels);
        double CalculateTotal();
    }
}
