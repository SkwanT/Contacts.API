using AutoMapper;
using Contacts.API.Entities;
using Contacts.API.Models;
using System.Linq;

namespace Contacts.API.DAL
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<Contact, ContactModel>()
                      .ForMember(c => c.TagName, opt => opt.MapFrom(m => m.TagName.TagGroup))
                      .ForMember(d => d.PhoneNumbers, o => o.MapFrom(s => s.PhoneNumbers.Select(c => c.Number).ToArray()))
                      .ForMember(d => d.Emails, o => o.MapFrom(s => s.Emails.Select(c => c.EmailAddress).ToArray()));






            CreateMap<ContactModel, Contact>()
               .ConstructUsing(item => new Contact
               {

                   //TagName =
                   //     new TagName
                   //     {
                   //         TagGroup = item.TagName
                   //     },
                   //PhoneNumbers = (item.PhoneNumbers).Select(x => new PhoneNumber { Number = x, ContactID=item.ID }).ToList(),
                   //Emails = (item.Emails).Select(x => new Email { EmailAddress = x, ContactID = item.ID }).ToList()

               })
               .ForMember(s => s.Emails, o => o.Ignore())
               .ForMember(s => s.PhoneNumbers, o => o.Ignore())
               .ForMember(s => s.TagName, o => o.Ignore());





        }
    }
}