using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAppAuth.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginRegister(List<string> errorMessages = null)
        {
            return View(errorMessages);
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password, string repeatPassword, string userName)
        {
            if (email == null || email == string.Empty || password == null || password == string.Empty || repeatPassword == null || repeatPassword == string.Empty)
            {
                return RedirectToAction("LoginRegister",
                    new { errorMessages = new List<string>() { "Incorrect data input." } });
            }

            if(password != repeatPassword)
            {
                return RedirectToAction("LoginRegister",
                    new { errorMessages = new List<string>() { "Passwords do not match." } });
            }

            if(await _userManager.FindByEmailAsync(email) != null)
            {
                return RedirectToAction("LoginRegister",
                    new { errorMessages = new List<string>() { "This e-mail already exists." } });
            }

            var passwordValidator = new PasswordValidator<IdentityUser>();
            var passwordValidateResult = await passwordValidator.ValidateAsync(_userManager, null, password);

            if (!passwordValidateResult.Succeeded)
            {
                return RedirectToAction("LoginRegister",
                    new { errorMessages = "Password Passwords must be at least 6 characters, at least one lowercase('a' - 'z'), at least one uppercase('A' - 'Z'), at least one digit('0' - '9'), at least one non alphanumeric character." } );
            }

            var user = new IdentityUser
            {
                Email = email,
                UserName = userName
            };

            var userCreateResult = await _userManager.CreateAsync(user, password);

            if (!userCreateResult.Succeeded)
            {
                return RedirectToAction("LoginRegister",
                    new { errorMessages = "An error occured when creating account. Try again later or contact support." });
            }

            return RedirectToAction("LoginRegister",
                    new { errorMessages = "Account created successfully. Confirm e-mail and log in." });
        }
    }
}
