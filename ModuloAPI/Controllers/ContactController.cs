using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuloAPI.Models;
using ModuloAPI.services;

namespace ModuloAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            var contacts = await _contactService.GetContacts();
            return Ok(contacts);
        }
    }
}
