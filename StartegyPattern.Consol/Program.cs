using StrategyPattern.Processor.Data;
using StrategyPattern.Processor.PriceCalculators;
using StrategyPattern.Processor.Processors;
using System;

namespace StartegyPattern.Consol
{
    class Program
    {
        static void Main(string[] args)
        {
            var productRepo = new ProductDbRepo();

            var products = productRepo.Products;

            foreach (var product in products)
                product.Quanitiy = 1;

            var billProcessorBase = new BillProcessor(new ProductPriceCalculator());
            billProcessorBase.GetProducts(productRepo.Products);

            var billProcessorLoyality = new BillProcessor(new ProductPriceCalculatorLoyalityCard());
            billProcessorLoyality.GetProducts(productRepo.Products);

            Console.WriteLine($"Base: {billProcessorBase.CalculateTotal()}");
            Console.WriteLine($"Loyality: {billProcessorLoyality.CalculateTotal()}");
        }
    }
}
