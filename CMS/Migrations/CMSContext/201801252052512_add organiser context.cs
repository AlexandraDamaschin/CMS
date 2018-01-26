namespace CMS.Migrations.CMSContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addorganisercontext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organisers",
                c => new
                    {
                        OrganiserId = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(nullable: false, maxLength: 255),
                        ContactDetails = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.OrganiserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Organisers");
        }
    }
}
