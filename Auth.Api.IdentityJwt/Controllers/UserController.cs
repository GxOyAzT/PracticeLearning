using Auth.Api.IdentityJwt.UserData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth.Api.IdentityJwt.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("Open")]
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
        [Route("connectionclose")]
        public async Task<IActionResult> ConnectionClose()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok();
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserModel userModel)
        {
            if (userModel == null)
                return BadRequest();

            var user = new IdentityUser()
            {
                UserName = userModel.Username,
                Email = ""
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserModel userModel)
        {
            var user = await _userManager.FindByNameAsync(userModel.Username);

            if (user != null)
            {
                return Ok(new { token = _generateToken.GenerateTokenMethod(user.Id) });
            }

            return NotFound();
        }
    }
}
