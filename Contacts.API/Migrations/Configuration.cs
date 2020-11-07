namespace Contacts.API.Migrations
{
    using Contacts.API.Entities;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Contacts.API.DAL.ContactsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Contacts.API.DAL.ContactsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Contacts.AddOrUpdate(x => x.ID,
                new Contact() { ID = 1, FirstName = "Joe 1", LastName = "Doe 1", Street = "Somewhere 1", City = "Big City", TagNameID = 2 },
                new Contact() { ID = 2, FirstName = "Joe 2", LastName = "Doe 2", Street = "Somewhere 2", City = "Big City", TagNameID = 1 },
                new Contact() { ID = 3, FirstName = "Joe 3", LastName = "Doe 3", Street = "Somewhere 3", City = "Big City" },
                new Contact() { ID = 4, FirstName = "Joe 4", LastName = "Doe 4", Street = "Somewhere 4", City = "Big City" },
                new Contact() { ID = 5, FirstName = "Joe 5", LastName = "Doe 5", Street = "Somewhere 5", City = "Big City" },
                new Contact() { ID = 6, FirstName = "Joe 6", LastName = "Doe 6", Street = "Somewhere 6", City = "Big City", TagNameID = 1 },
                new Contact() { ID = 7, FirstName = "Joe 7", LastName = "Doe 7", Street = "Somewhere 7", City = "Big City" },
                new Contact() { ID = 8, FirstName = "Joe 8", LastName = "Doe 8", Street = "Somewhere 8", City = "Big City", TagNameID = 1 },
                new Contact() { ID = 9, FirstName = "Joe 9", LastName = "Doe 9", Street = "Somewhere 9", City = "Big City" }

            );

            context.Emails.AddOrUpdate(x => x.ID,
                new Email() { ID = 1, EmailAddress = "joe1@doe1.com", ContactID = 1 },
                new Email() { ID = 2, EmailAddress = "joe2@doe2.com", ContactID = 2 },
                new Email() { ID = 3, EmailAddress = "joe3@doe3.com", ContactID = 3 },
                new Email() { ID = 4, EmailAddress = "joe4@doe4.com", ContactID = 4 }
            );

            context.PhoneNumbers.AddOrUpdate(x => x.ID,
                new PhoneNumber() { ID = 1, Number = "098/380380", ContactID = 1 },
                new PhoneNumber() { ID = 2, Number = "098/381381", ContactID = 1 },
                new PhoneNumber() { ID = 3, Number = "099 000000", ContactID = 2 },
                new PhoneNumber() { ID = 4, Number = "091 111111", ContactID = 3 },
                new PhoneNumber() { ID = 5, Number = "099 000001", ContactID = 4 },
                new PhoneNumber() { ID = 6, Number = "099 000002", ContactID = 5 },
                new PhoneNumber() { ID = 7, Number = "099 000003", ContactID = 6 },
                new PhoneNumber() { ID = 8, Number = "099 000004", ContactID = 7 },
                new PhoneNumber() { ID = 9, Number = "099 000005", ContactID = 8 },
                new PhoneNumber() { ID = 10, Number = "099 000006", ContactID = 9 }
            );


            context.TagNames.AddOrUpdate(x => x.ID,
              new TagName() { ID = 1, TagGroup = "friends" },
              new TagName() { ID = 2, TagGroup = "family" }
            );


        }
    }
}
