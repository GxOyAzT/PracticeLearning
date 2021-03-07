using AutoMapper;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.Api.Controllers
{
    [ApiController]
    [Route("api1.1/[controller]")]
    [EnableCors("FirstPolicy")]
    public class EmployeeExtensionController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeExtensionController(
                IEmployeeRepo employeeRepo,
                IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Count")]
        public IActionResult Count()
        {
            return Ok(new { TotalEmployee = _employeeRepo.Count() });
        }

        [HttpGet]
        [Route("GetEmployeePaged")]
        public IActionResult GetEmployeePaged(int? page ,int? count)
        {
            if (!page.HasValue || !count.HasValue)
            {
                return BadRequest(new { ErrorMessage = "page or count was not initialized." });
            }

            var returnModels = _employeeRepo.GetPaged(count.Value, page.Value);

            return Ok(_mapper.Map<IEnumerable<EmployeeBasicDTO>>(returnModels));
        }
    }
}
