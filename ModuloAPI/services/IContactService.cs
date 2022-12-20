using ModuloAPI.Models;

namespace ModuloAPI.services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContacts();
    }
}
