using Auth.JwtIdentity.TenantDb.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Auth.JwtIdentity.TenantDb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PeopleController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [Authorize]
        [Route("people")]
        public IActionResult GetPeople()
        {
            return Ok(_appDbContext.PersonModels.ToList());
        }
    }
}
