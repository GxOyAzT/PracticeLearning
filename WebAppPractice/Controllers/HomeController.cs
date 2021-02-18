using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAppPractice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Private()
        {
            return Index();
        }

        [HttpGet]
        public IActionResult DatePractice()
        {
            ModelForReleaseProp model = new ModelForReleaseProp() { ReleaseDate = DateTime.Now.Date.AddDays(10) };
            return View(model);
        }

        [HttpGet]
        public IActionResult PracticeAspForList()
        {
            var model = new PracticeAspForListViewModel()
            {
                Employees = new System.Collections.Generic.List<Employee>() 
                {
                    new Employee()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Emp 1",
                        Contract = Contract.B2B
                    },
                    new Employee()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Emp 2",
                        Contract = Contract.Intern
                    }
                }
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult PracticeAspForList(PracticeAspForListViewModel model)
        { 
            return View();
        }
    }
}
