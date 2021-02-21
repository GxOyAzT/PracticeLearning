using AutoMapper;
using EmployeeManagement.DatabaseManager;
using EmployeeManagement.DataModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public ActionResult<List<EmployeeBasicDTO>> GetEmployees()
        {
            return Ok(_mapper.Map<IEnumerable<EmployeeBasicDTO>>(_employeeRepo.Get()));
        }

        [HttpGet("{id}")]
        public ActionResult <EmployeeBasicDTO> GetEmployeeById(string id)
        {
            return Ok(_mapper.Map<EmployeeBasicDTO>(_employeeRepo.Get().FirstOrDefault(e => e.Id == Guid.Parse(id))));
        }

        [HttpPost]
        public ActionResult InsertNewEmployee(EmployeeBasicDTO modelDTO)
        {
            var employee = _mapper.Map<EmployeeModel>(modelDTO);
            employee.Id = Guid.NewGuid();
            _employeeRepo.Insert(employee);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(string id)
        {
            Guid id_guid;
            if (Guid.TryParse(id, out id_guid))
            {
                return NotFound(new ErrorMessageDTO("Incorret employee ID format.", 101));
            }

            _employeeRepo.Delete(id_guid);

            return Ok();
        }
    }
}
