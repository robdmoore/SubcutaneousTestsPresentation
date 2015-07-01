namespace SubcutaneousTestsPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PersonalDetails_Title = c.String(),
                        PersonalDetails_FirstName = c.String(),
                        PersonalDetails_LastName = c.String(),
                        PersonalDetails_Email = c.String(),
                        PersonalDetails_Telephone = c.String(),
                        PersonalDetails_Fax = c.String(),
                        PostalAddress_Line1 = c.String(),
                        PostalAddress_Line2 = c.String(),
                        PostalAddress_Line3 = c.String(),
                        PostalAddress_City = c.String(),
                        PostalAddress_State = c.String(),
                        PostalAddress_Postcode = c.String(),
                        PostalAddress_Country = c.String(),
                        Password_Value = c.String(),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        LastModifiedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
        }
    }
}
