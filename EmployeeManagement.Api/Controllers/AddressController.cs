using AutoMapper;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmployeeManagement.Api.Controllers
{
    [ApiController]
    [Route("api1.1/[controller]")]
    [EnableCors("Open")]
    public class AddressController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepo _addressRepo;

        public AddressController(
            IMapper mapper, IAddressRepo addressRepo)
        {
            _mapper = mapper;
            _addressRepo = addressRepo;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddressBasicDTO addressDTO)
        {
            var address = _mapper.Map<AddressModel>(addressDTO);

            _addressRepo.Insert(address);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] AddressBasicDTO addressDTO)
        {
            if (addressDTO.Id == Guid.Empty)
                return NotFound();

            var addressToDelete = _addressRepo.Get(addressDTO.Id);

            if (addressToDelete == null)
                return NotFound();

            _addressRepo.Delete(addressToDelete);

            return Ok();
        }
    }
}
