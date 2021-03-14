using Microsoft.AspNetCore.Mvc;
using StrategyPattern.Processor.Data;
using StrategyPattern.Processor.PriceCalculators;
using StrategyPattern.Processor.Processors;

namespace StrategyPattern.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillProcessController : ControllerBase
    {
        private readonly IBillProcessor _billProcessor;
        private readonly ProductDbRepo productDbRepo;

        public BillProcessController(IBillProcessor billProcessor)
        {
            _billProcessor = billProcessor;
            productDbRepo = new ProductDbRepo();
        }

        [HttpGet]
        public IActionResult Get(int calculateType = -1)
        {
            var productList = productDbRepo.Products;

            switch (calculateType)
            {
                case 1:
                    _billProcessor.SetCalculator(new ProductPriceCalculator());
                    break;
                case 2:
                    _billProcessor.SetCalculator(new ProductPriceCalculatorSaturdayDiscount());
                    break;
                case 3:
                    _billProcessor.SetCalculator(new ProductPriceCalculatorLoyalityCard());
                    break;
                default:
                    return BadRequest();
            }

            _billProcessor.GetProducts(productList);

            return Ok(_billProcessor.CalculateTotal());
        }
    }
}
