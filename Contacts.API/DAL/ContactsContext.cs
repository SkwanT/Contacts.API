using Contacts.API.Entities;
using System.Data.Entity;

namespace Contacts.API.DAL
{
    public class ContactsContext : DbContext
    {
        public ContactsContext() : base("ContactsContext")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<TagName> TagNames { get; set; }
    }
}