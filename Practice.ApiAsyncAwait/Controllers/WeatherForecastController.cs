using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Practice.ApiAsyncAwait.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("a")]
        public IActionResult GetA()
        {
            x();
            return Ok("aa");
        }

        [HttpGet]
        [Route("b")]
        public IActionResult GetB()
        {
            x();
            return Ok("bb");
        }

        private void x()
        {
            Thread.Sleep(5000);
        } 
    }
}
