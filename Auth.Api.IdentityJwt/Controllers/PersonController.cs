using Auth.Api.IdentityJwt.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth.Api.IdentityJwt.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public PersonController()
        {

        }

        [HttpGet]
        [Route("people")]
        public IActionResult Get()
        {
            //var user = User.FindFirst();

            List<PersonModel> personModels = new List<PersonModel>()
            {
                new PersonModel() { Id = 1, Name = "Person-1" },
                new PersonModel() { Id = 2, Name = "Person-2" },
                new PersonModel() { Id = 3, Name = "Person-3" },
                new PersonModel() { Id = 4, Name = "Person-4" },
            };

            var output = JsonConvert.SerializeObject(personModels);

            return Ok(output);
        }
    }
}
