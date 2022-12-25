using Microsoft.EntityFrameworkCore;
using ModuloAPI.Context;
using ModuloAPI.Models;
using ModuloAPI.Repository;

namespace ModuloAPI.services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Contact> CreateContact(Contact contact)
        {
            if (contact == null)
            {
                throw new Exception("É necessário informar os Dados para criação de um contato");
            }
            if(contact.Name == null)
            {
                throw new Exception("É necessário informar um nome para criação um contato");
            }
            await _contactRepository.CreateContact(contact);
            return contact;
        }
        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _contactRepository.GetContacts();
        }

        public async Task<Contact> GetContactById(int id)
        {
            Contact contact = await _contactRepository.GetContactById(id);
            if (contact == null)
            {
                throw new Exception($"Não existem registros com o ID {id}");
            }
            return contact;
        }


        public async Task<Contact> UpdateContact(Contact contact, int id)
        {
            var contactUpd = await _contactRepository.UpdateContact(contact, id);
            return contactUpd;
        }

        public async Task<bool> DeleteContact(int id)
        {
            return await _contactRepository.DeleteContact(id);

        }
    }
}
