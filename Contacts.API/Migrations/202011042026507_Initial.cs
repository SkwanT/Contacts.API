namespace Contacts.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false, maxLength: 128),
                        Street = c.String(maxLength: 128),
                        City = c.String(maxLength: 128),
                        TagNameID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TagNames", t => t.TagNameID)
                .Index(t => t.TagNameID);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(maxLength: 50),
                        ContactID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contacts", t => t.ContactID, cascadeDelete: true)
                .Index(t => t.ContactID);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Number = c.String(maxLength: 20),
                        ContactID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contacts", t => t.ContactID, cascadeDelete: true)
                .Index(t => t.ContactID);
            
            CreateTable(
                "dbo.TagNames",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TagGroup = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "TagNameID", "dbo.TagNames");
            DropForeignKey("dbo.PhoneNumbers", "ContactID", "dbo.Contacts");
            DropForeignKey("dbo.Emails", "ContactID", "dbo.Contacts");
            DropIndex("dbo.PhoneNumbers", new[] { "ContactID" });
            DropIndex("dbo.Emails", new[] { "ContactID" });
            DropIndex("dbo.Contacts", new[] { "TagNameID" });
            DropTable("dbo.TagNames");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.Emails");
            DropTable("dbo.Contacts");
        }
    }
}
