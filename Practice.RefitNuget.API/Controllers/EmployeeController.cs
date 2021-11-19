using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.RefitNuget.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.RefitNuget.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        public static List<EmployeeModel> Employees = new()
        {
            new() { Id = 1, FirstName = "FirstName1", LastName = "LastName1" },
            new() { Id = 2, FirstName = "FirstName2", LastName = "LastName2" },
            new() { Id = 3, FirstName = "FirstName3", LastName = "LastName3" }
        };

        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok(Employees);
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var employee = Employees.FirstOrDefault(e => e.Id == id);

            if (employee is null)
            {
                return NotFound($"Cannot find EmployeeModel of id {id}");
            }

            return Ok(employee);
        }

        [HttpPost("post")]
        public IActionResult Post([FromBody] EmployeeModel employeeModel)
        {
            Employees.Add(new EmployeeModel()
            {
                Id = Employees.Max(e => e.Id) + 1,
                FirstName = employeeModel.FirstName,
                LastName = employeeModel.LastName
            });
            return Ok();
        }

        [HttpPut("put/{id}")]
        public IActionResult Put(int id, [FromBody] EmployeeModel employeeModel)
        {
            Employees.Remove(Employees.FirstOrDefault(e => e.Id == id));
            Employees.Add(employeeModel);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            Employees.Remove(Employees.FirstOrDefault(e => e.Id == id));
            return Ok();
        }
    }
}
