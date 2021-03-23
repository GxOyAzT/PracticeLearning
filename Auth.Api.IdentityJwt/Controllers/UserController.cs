using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth.Api.IdentityJwt.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IGenerateToken _generateToken;

        public UserController(UserManager<IdentityUser> userManager, IGenerateToken generateToken)
        {
            _userManager = userManager;
            _generateToken = generateToken;
        }

        [HttpGet]
        [Route("connectionOpen")]
        [AllowAnonymous]
        public IActionResult ConnectionOpen()
        {
            return Ok();
        }

        [HttpGet]
        [Route("connectionClose")]
        public async Task<IActionResult> ConnectionClose()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok();
        }

        [HttpGet]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string userName, string password)
        {
            var user = new IdentityUser()
            {
                UserName = userName,
                Email = ""
            };

            var result = await _userManager.CreateAsync(user, password);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                return Ok(new { token = _generateToken.GenerateTokenMethod(user.Id) });
            }

            return NotFound();
        }
    }
}
