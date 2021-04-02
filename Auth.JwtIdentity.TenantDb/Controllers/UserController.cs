using Auth.JwtIdentity.TenantDb.Models;
using Auth.JwtIdentity.TenantDb.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.JwtIdentity.TenantDb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AplicationUser> _userManager;
        private readonly IGenerateToken _generateToken;

        public UserController(UserManager<AplicationUser> userManager, IGenerateToken generateToken)
        {
            _userManager = userManager;
            _generateToken = generateToken;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserModel userModel)
        {
            if (userModel == null)
                return BadRequest();

            var user = new AplicationUser()
            {
                UserName = userModel.Username,
                Email = ""
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserModel userModel)
        {
            var user = await _userManager.FindByNameAsync(userModel.Username);

            if (user != null)
            {
                return Ok(new { token = _generateToken.GenerateTokenMethod(user.Id) });
            }

            return NotFound();
        }

        [HttpPost]
        [Route("loginadmin")]
        public async Task<IActionResult> LoginAdmin([FromBody] UserModel userModel)
        {
            var user = await _userManager.FindByNameAsync(userModel.Username);

            if (user != null)
            {
                return Ok(new { token = _generateToken.GenerateTokenMethodWithAdminPermissions(user.Id) });
            }

            return NotFound();
        }
    }
}
