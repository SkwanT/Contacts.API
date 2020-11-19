namespace Contacts.API.Models
{
    public class ContactModel
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string[] PhoneNumbers { get; set; }
        public string[] Emails { get; set; }

        public string TagName { get; set; }
    }
}