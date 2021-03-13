using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern.Processor.PriceCalculators
{
    public class ProductPriceResolver
    {
        public IProductPriceCalculator Resolve(ProductPriceResolverEnum resolerSwitch)
        {
            switch (resolerSwitch)
            {
                case ProductPriceResolverEnum.Starndard:
                    return new ProductPriceCalculator();
                case ProductPriceResolverEnum.SaturdayDiscount:
                    return new ProductPriceCalculatorSaturdayDiscount();
                case ProductPriceResolverEnum.LoyalityCard:
                    return new ProductPriceCalculatorLoyalityCard();
                default:
                    throw new NotImplementedException();
            }
        }
    }

    public enum ProductPriceResolverEnum
    {
        Starndard,
        LoyalityCard,
        SaturdayDiscount
    }
}
