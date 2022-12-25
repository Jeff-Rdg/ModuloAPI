using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact(Contact contact)
        {
            var result = await _contactService.CreateContact(contact);
            return CreatedAtAction(nameof(GetContactById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            var contacts = await _contactService.GetContacts();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactById(int id)
        {
            Contact contact = await _contactService.GetContactById(id);
            return Ok(contact);
        }

        [HttpPut]
        public async Task<ActionResult<Contact>> UpdateContact([FromBody] Contact contact, int id)
        {
            Contact result = await _contactService.UpdateContact(contact, id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Contact>> DeleteContact(int id)
        {
            var result = await _contactService.DeleteContact(id);
            if (result)
            {
                return Ok($"Contato com id {id} deletado com sucesso!");
            }
            else
            {
                return BadRequest("Houve um problema.");
            }
        }

    }
}
