using Contacts.API.Entities;
using Contacts.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Contacts.API.DAL
{
    public class ContactInteractor : IContactInteractor
    {
        private readonly IContactRepository _repository;

        public ContactInteractor(IContactRepository repository)
        {
            _repository = repository;

        }


        public ICollection<PhoneNumber> PrepareList(ICollection<PhoneNumber> phonenumberlist, ContactModel model)
        {
            while (phonenumberlist.ToList().Count() < model.PhoneNumbers.Length)
                phonenumberlist.Add(new PhoneNumber());


            while (phonenumberlist.ToList().Count() > model.PhoneNumbers.Length)
                _repository.DeletePhoneNumber(phonenumberlist.LastOrDefault());


            int i = 0;
            foreach (var item in phonenumberlist)
                item.Number = model.PhoneNumbers[i++];

            return phonenumberlist;
        }

        public ICollection<Email> PrepareList(ICollection<Email> emaillist, ContactModel model)
        {
            while (emaillist.ToList().Count() < model.Emails.Length)
            {
                emaillist.Add(new Email());
            }

            while (emaillist.ToList().Count() > model.Emails.Length)
            {
                _repository.DeleteEmail(emaillist.LastOrDefault());
            }

            int i = 0;
            foreach (var item in emaillist)
                item.EmailAddress = model.Emails[i++];

            return emaillist;
        }





    }
}