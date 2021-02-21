using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [ApiController]
    [Route("/api1.1/[controller]")]
    public class TestsController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok("Hello");
        }
    }
}
