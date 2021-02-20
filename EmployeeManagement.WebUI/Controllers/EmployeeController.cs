using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.WebUI.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeController()
        {

        }

        public IActionResult EmployeeList()
        {
            return View();
        }
    }
}
