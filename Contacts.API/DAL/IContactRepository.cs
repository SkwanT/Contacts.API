using Contacts.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.API.DAL
{
    public interface IContactRepository : IDisposable
    {
        IEnumerable<Contact> GetAllContacts();

        Task<IEnumerable<Contact>> GetAllContactsAsync(string searchValue);

        Task<Contact> GetContactAsync(int id);

        Task<TagName> GetTagName(string tag);

        bool AddTagName(TagName tag);

        bool AddContact(Contact contact);

        bool DeleteContact(Contact contact);

        bool DeletePhoneNumber(PhoneNumber phoneNumber);

        bool DeleteEmail(Email email);



        Task<bool> SaveChangesAsync();
    }
}
