using Contacts.API.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.API.DAL
{
    public class ContactRepository : IContactRepository
    {

        private ContactsContext _context;
        public ContactRepository(ContactsContext context)
        {
            _context = context;
        }


        public IEnumerable<Contact> GetAllContacts()
        {

            return _context.Contacts.ToList();
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync(string searchValue)
        {

            if (!string.IsNullOrEmpty(searchValue))
                return await _context.Contacts.Include(t => t.TagName).Where(c => c.FirstName.ToLower().Contains(searchValue.ToLower()) ||
                                                      c.LastName.ToLower().Contains(searchValue.ToLower()) ||
                                                      c.TagName.TagGroup.ToLower().Contains(searchValue.ToLower()))
                                                      .ToListAsync();


            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactAsync(int id)
        {

            return await _context.Contacts.Include(p => p.PhoneNumbers).Include(e => e.Emails).Include(t => t.TagName).Where(c => c.ID == id).FirstOrDefaultAsync();
        }


        public async Task<TagName> GetTagName(string tag)
        {

            var tagname = await _context.TagNames.Where(x => x.TagGroup.Equals(tag)).FirstOrDefaultAsync();

            if (tagname != null)
            {
                return tagname;
            }

            try
            {
                TagName t = new TagName();
                t.TagGroup = tag;

                AddTagName(t);

                tagname = await _context.TagNames.Where(x => x.TagGroup.Equals(tag)).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }

            return tagname;
        }


        public bool AddTagName(TagName tag)
        {

            try
            {
                _context.TagNames.Add(tag);
                _context.SaveChanges();

            }
            catch
            {
                return false;
            }

            return true;
        }


        public bool AddContact(Contact contact)
        {
            try
            {
                _context.Contacts.Add(contact);
            }
            catch
            {

                return false;
            }

            return true;
        }

        public bool DeleteContact(Contact contact)
        {
            try
            {
                _context.Contacts.Remove(contact);
            }
            catch
            {

                return false;
            }

            return true;
        }

        public bool DeletePhoneNumber(PhoneNumber phoneNumber)
        {
            try
            {
                _context.PhoneNumbers.Remove(phoneNumber);
                _context.SaveChanges();
            }
            catch
            {

                return false;
            }

            return true;
        }

        public bool DeleteEmail(Email email)
        {
            try
            {
                _context.Emails.Remove(email);
                _context.SaveChanges();
            }
            catch
            {

                return false;
            }

            return true;
        }


        public async Task<bool> SaveChangesAsync()
        {
            try
            {

                await _context.SaveChangesAsync();
            }
            catch
            {

                return false;
            }


            return true;
        }






        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}