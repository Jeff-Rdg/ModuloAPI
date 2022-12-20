using Microsoft.EntityFrameworkCore;
using ModuloAPI.Context;
using ModuloAPI.Models;

namespace ModuloAPI.services
{
    public class ContactService : IContactService
    {
        private readonly ContactContext _contactContext;

        public ContactService(ContactContext contactContext)
        {
            _contactContext = contactContext;
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _contactContext.Contacts.ToListAsync();
        }
    }
}
