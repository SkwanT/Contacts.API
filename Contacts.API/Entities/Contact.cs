using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contacts.API.Entities
{
    public class Contact
    {

        public int ID { get; set; }
        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(128)]
        public string LastName { get; set; }
        [StringLength(128)]

        public string Street { get; set; }

        [StringLength(128)]
        public string City { get; set; }

        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public virtual ICollection<Email> Emails { get; set; }

        public int? TagNameID { get; set; }
        public virtual TagName TagName { get; set; }



    }
}