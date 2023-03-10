using ModuloAPI.Models;

namespace ModuloAPI.services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> GetContactById(int id);
        Task<Contact> CreateContact(Contact contact);
        Task<Contact> UpdateContact(Contact contact, int id);
        Task<bool> DeleteContact(int id);
    }
}
