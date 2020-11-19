using System.ComponentModel.DataAnnotations;

namespace Contacts.API.Entities
{
    public class Email
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [Required]
        public int ContactID { get; set; }

        public virtual Contact Contact { get; set; }
    }
}