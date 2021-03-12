using AutoMapper;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeManagement.Api.Controllers
{
    [ApiController]
    [Route("api1.1/[controller]")]
    [EnableCors("Open")]
    public class DepartmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepo _departmentRepo;

        public DepartmentController(IMapper mapper, IDepartmentRepo departmentRepo)
        {
            _mapper = mapper;
            _departmentRepo = departmentRepo;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            return Ok(_mapper.Map<IEnumerable<DepartmentDTO>>(_departmentRepo.Get()));
        }
    }
}
