using Microsoft.EntityFrameworkCore;
using ModuloAPI.Context;
using ModuloAPI.Models;

namespace ModuloAPI.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactContext _context;

        public ContactRepository(ContactContext context)
        {
            _context = context;
        }

        public async Task<Contact> CreateContact(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return contact;
        }
        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _context.Contacts.ToListAsync();
        }
        public async Task<Contact> GetContactById(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Contact> UpdateContact(Contact contact, int id)
        {
            Contact contactId = await GetContactById(id);

            if(contactId == null)
            {
                throw new Exception($"Contato para o ID {id} não existe.");
            }

            contactId.Name = contact.Name;
            contactId.Phone = contact.Phone;
            contactId.IsActive = contact.IsActive;

            _context.Contacts.Update(contactId);
            await _context.SaveChangesAsync();

            return contactId;
        }

        public async Task<bool> DeleteContact(int id)
        {
            Contact contactId = await GetContactById(id);

            if (contactId == null)
            {
                throw new Exception($"Contato para o ID {id} não existe.");
            }

            _context.Contacts.Remove(contactId);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
