using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.JwtIdentity.TenantDb.Controllers
{
    [ApiController]
    [Route("api/permissions")]
    public class PermissionController : ControllerBase
    {
        public PermissionController()
        {

        }

        [HttpGet]
        [Route("administrator")]
        [Authorize(Policy = "admin")]
        public IActionResult Admin()
        {
            return Ok("Admin");
        }

        [HttpGet]
        [Route("user")]
        [Authorize]
        public IActionResult CommonUser()
        {
            return Ok("User");
        }
    }
}
