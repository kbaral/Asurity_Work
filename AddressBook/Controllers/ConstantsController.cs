using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.LiteDb.Constants;
using AddressBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstantsController : ControllerBase
    {
        private readonly IConstantService _constantService;

        public ConstantsController(IConstantService constantService)
        {
            _constantService = constantService;
        }

        // GET: api/Constants
        [HttpGet]
        public ActionResult<Constants> Get()
        {
            var dropdownOptions = new Constants()
            {
                ContactFreqOptions = new[] {
                    "Contact only about account information",
                    "OK to contact with marketing information",
                    "OK to contact with third-party marketing information",
                },
                ContactMethodOptions = new[]
                {
                    "Text",
                    "Email",
                    "Phone",
                }
            };
            return dropdownOptions;
        }

        // GET: api/Constants/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Constants
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Constants/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
