using Microsoft.AspNetCore.Mvc;
using SeveralDatabasesApproach.Data;
using System.Linq;

namespace SeveralDatabasesApproach.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public TestController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [Route("index")]
        public IActionResult Index()
        {
            var ans = appDbContext.PersonModels.ToList();

            return Ok();
        }
    }
}
