using AutoMapper;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    [ApiController]
    [Route("api1.1/[controller]")]
    [EnableCors("FirstPolicy")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeController(
            IEmployeeRepo employeeRepo,
            IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_mapper.Map<IEnumerable<EmployeeBasicDTO>>(_employeeRepo.Get()));
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(string id)
        {
            Guid employeeId;

            if (!Guid.TryParse(id, out employeeId))
            {
                var error = new ErrorMessageDTO("Cannot convert id", 101);
                return BadRequest(error);
            }

            var employeeDTO = _employeeRepo.Get(employeeId);

            if (employeeDTO == null)
            {
                var error = new ErrorMessageDTO($"Cannot find user of id {id}", 101);
                return BadRequest(error);
            }

            return Ok(_mapper.Map<EmployeeBasicDTO>(employeeDTO));
        }

        [HttpPost]
        public IActionResult InsertNewEmployee([FromBody] EmployeeBasicDTO modelDTO)
        {
            var employee = _mapper.Map<EmployeeModel>(modelDTO);

            if (String.IsNullOrWhiteSpace(modelDTO.FullName))
            {
                var error = new ErrorMessageDTO("FullName property cannot be null or empty", 201);
                return BadRequest(error);
            }

            var returnEmployee = _employeeRepo.Insert(employee);

            return Ok(_mapper.Map<EmployeeBasicDTO>(returnEmployee));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(string id)
        {
            Guid employeeId;

            if (!Guid.TryParse(id, out employeeId))
                return BadRequest(new ErrorMessageDTO("Incorret employee id format", 101));

            if (!_employeeRepo.Delete(employeeId))
                return NotFound(new ErrorMessageDTO($"Cannot find user of id {id}", 101));

            return Ok();
        }
    }
}
