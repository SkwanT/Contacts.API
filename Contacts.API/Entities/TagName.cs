using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contacts.API.Entities
{
    public class TagName
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string TagGroup { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}