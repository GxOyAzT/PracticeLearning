using Auth.Api.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Auth.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleDataController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData()
        {
            List<ExampleDataModel> exampleDataModels = new List<ExampleDataModel>();

            exampleDataModels.Add(new ExampleDataModel() { GuidProp = Guid.NewGuid(), IntProp = 1, StringProp = "String 1" });
            exampleDataModels.Add(new ExampleDataModel() { GuidProp = Guid.NewGuid(), IntProp = 2, StringProp = "String 2" });
            exampleDataModels.Add(new ExampleDataModel() { GuidProp = Guid.NewGuid(), IntProp = 3, StringProp = "String 3" });

            return Ok(exampleDataModels);
        }
    }
}
