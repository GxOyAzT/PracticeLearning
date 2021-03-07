using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpGet]
        public IActionResult EmployeeA()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EmployeePagedList()
        {
            return View();
        }
    }
}
