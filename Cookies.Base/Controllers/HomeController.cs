using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cookies.Base.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateCookie()
        {
            Response.Cookies.Append("MyCookie", "abc");
            return Ok();
        }

        public IActionResult ReadCookie()
        {
            string cookie = Request.Cookies["MyCookie"];
            return Ok(cookie);
        }
    }
}
