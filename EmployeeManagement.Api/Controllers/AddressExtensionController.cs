using AutoMapper;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.Api.Controllers
{
    [ApiController]
    [Route("api1.1/[controller]")]
    [EnableCors("Open")]
    public class AddressExtensionController : ControllerBase
    {
        private readonly IAddressRepo _addressRepo;
        private readonly IMapper _mapper;

        public AddressExtensionController(
            IAddressRepo addressRepo, 
            IMapper mapper)
        {
            _addressRepo = addressRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetEmployeeAddresses")]
        public IActionResult GetEmployeeAddresses ([FromQuery] Guid employeeId)
        {
            if (employeeId == Guid.Empty)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<AddressBasicDTO>>(_addressRepo.GetByEmployeeId(employeeId)));
        }
    }
}
