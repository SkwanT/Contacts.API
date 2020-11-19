using Contacts.API.Entities;
using Contacts.API.Models;
using System.Collections.Generic;

namespace Contacts.API.DAL
{
    public interface IContactInteractor : IGenericPrepare<Email>, IGenericPrepare<PhoneNumber>
    {
    }

    public interface IGenericPrepare<T> where T : class
    {
        ICollection<T> PrepareList(ICollection<T> list, ContactModel model);
    }
}