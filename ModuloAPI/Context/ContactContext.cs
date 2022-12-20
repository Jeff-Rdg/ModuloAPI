using Microsoft.EntityFrameworkCore;
using ModuloAPI.Models;

namespace ModuloAPI.Context
{
    public class ContactContext : DbContext
    {
       
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
            
        }

        public DbSet<Contact> Contacts { get; set; }


    }
}
