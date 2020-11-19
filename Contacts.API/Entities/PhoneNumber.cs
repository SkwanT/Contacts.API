using System.ComponentModel.DataAnnotations;

namespace Contacts.API.Entities
{
    public class PhoneNumber
    {
        public int ID { get; set; }

        [StringLength(20)]
        public string Number { get; set; }

        [Required]
        public int ContactID { get; set; }

        public virtual Contact Contact { get; set; }
    }
}