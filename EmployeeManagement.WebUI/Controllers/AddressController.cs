using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.DataModel;
using System;

namespace EmployeeManagement.WebUI.Controllers
{
    public class AddressController : Controller
    {
        public AddressController()
        {
        }

        public IActionResult Index()
        {
            return Json("Hello");
        }

        [HttpPost]
        public IActionResult GetPartialAddress([FromBody] AddressBasicDTO addressBasicDTO)
        {
            return View("~/Views/Address/_AddressPartial.cshtml", addressBasicDTO);
        }
    }
}
