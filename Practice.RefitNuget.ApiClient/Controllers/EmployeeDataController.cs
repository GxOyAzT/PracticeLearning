using Microsoft.AspNetCore.Mvc;
using Practice.RefitNuget.ApiClient.DataAccess;
using Practice.RefitNuget.ApiClient.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practice.RefitNuget.ApiClient.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeDataController : ControllerBase
    {
        private readonly IEmployeeData _employeeData;

        public EmployeeDataController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet("get")]
        public async Task<List<EmployeeModel>> Get()
        {
            var employees = await _employeeData.GetEmployees();

            return employees;
        }

        [HttpGet("get/{id}")]
        public async Task<EmployeeModel> Get(int id)
        {
            try
            {
                var employee = await _employeeData.GetEmployee(id);
                return employee;
            }
            catch (ApiException ex)
            {
                var message = ex.Content;
                return new EmployeeModel();
            }
        }

        [HttpPost("post")]
        public async Task Post([FromBody] EmployeeModel employee)
        {
            await _employeeData.CreateEmployee(employee);
        }

        [HttpDelete("get/{id}")]
        public async Task Delete(int id)
        {
            await _employeeData.DeleteEmployee(id);
        }
    }
}
