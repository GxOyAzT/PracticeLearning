using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        public HomeController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "Claim.DoB")]
        public IActionResult SecretPolicy()
        {
            return View("Secret");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult SecretRole()
        {
            return View("Secret");
        }

        public IActionResult Authenticate()
        {
            var grandmaClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Bob"),
                new Claim(ClaimTypes.Email, "Bob@emial.test"),
                new Claim(ClaimTypes.DateOfBirth, "11/11/2000"),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim("Grandma.Says", "Very nice boi."),
            };

            var grandmaIdentity = new ClaimsIdentity(grandmaClaims, "Grandma Identity");

            var licenceClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Bob K Foo"),
                new Claim("DravingLicense", "A+"),
            };

            var licenseClaims = new ClaimsIdentity(licenceClaims, "Government");

            var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity, licenseClaims });

            HttpContext.SignInAsync(userPrincipal);

            return View();
        }

        public async Task<IActionResult> DoStuff()
        {
            var builder = new AuthorizationPolicyBuilder("Schema");
            var customPolicy = builder.RequireClaim("Hello").Build();

            var authResult = await _authorizationService.AuthorizeAsync(User, customPolicy);

            if (authResult.Succeeded)
            {

            }

            return View("Index");
        }
    }
}
