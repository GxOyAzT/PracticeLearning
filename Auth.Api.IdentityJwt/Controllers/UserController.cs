using Auth.Api.IdentityJwt.UserData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Auth.Api.IdentityJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly TokenService _tokenService;

        public UserController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            TokenService tokenService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpGet]
        [Route("connectionopen")]
        [AllowAnonymous]
        public IActionResult ConnectionOpen()
        {
            return Ok();
        }

        [HttpGet]
        [Route("connectionauth")]
        public IActionResult ConnectionAuth()
        {
            var user = User.FindFirst("Name");
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            var user = new IdentityUser() { UserName = userDTO.UserName };

            await _userManager.CreateAsync(user, userDTO.Password);

            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
        {
            var user = await _userManager.FindByNameAsync(userDTO.UserName);

            if (user == null)
            {
                return NotFound();
            }

            if (await _userManager.CheckPasswordAsync(user, userDTO.Password))
            {
                return Unauthorized();
            }

            var token = _tokenService.GenerateToken(user.Id);

            var returnUserData = new UserDTO()
            {
                Id = user.Id,
                UserName = user.UserName,
                Token = token
            };

            return Ok(returnUserData);
        }
    }
}
