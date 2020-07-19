using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.LiteDb;
using AddressBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET: api/Contacts
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _contactService.FindAll();
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            var result = _contactService.FindOne(id);
            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }

        // POST: api/Contacts
        [HttpPost]
        public ActionResult<int> Insert(Contact contactObj)
        {
            var id = _contactService.Insert(contactObj);
            if (id != default)
                return id;
            else
                return BadRequest();
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public ActionResult<bool> Update(int id, [FromBody]Contact contactObj)
        {
            var result = _contactService.Update(contactObj);
            if (result)
                return true;
            else
                return NotFound();
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var result = _contactService.Delete(id);
            if (result)
                return true;
            else
                return NotFound();
        }
    }
}
