using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.IdentityJwt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }

        [Route("connection")]
        public IActionResult Connection()
        {
            return Ok();
        }
    }
}
