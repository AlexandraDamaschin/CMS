namespace CMS.Migrations.CMSContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodelrestrictionsconstraints : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Location", "Town", c => c.String(maxLength: 255));
            AddColumn("dbo.Location", "County", c => c.String(maxLength: 255));
            AddColumn("dbo.Event", "Organiser_OrganiserId", c => c.Int());
            AddColumn("dbo.EventCategory", "Free", c => c.Boolean(nullable: false));
            AddColumn("dbo.EventCategory", "Icon", c => c.String());
            AlterColumn("dbo.Location", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Event", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Event", "Details", c => c.String(maxLength: 255));
            AlterColumn("dbo.EventCategory", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Event", "Organiser_OrganiserId");
            AddForeignKey("dbo.Event", "Organiser_OrganiserId", "dbo.Organisers", "OrganiserId");
            DropColumn("dbo.Event", "OrganiserId");
            DropColumn("dbo.Event", "Owner");
            DropColumn("dbo.EventCategory", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventCategory", "ImageUrl", c => c.String());
            AddColumn("dbo.Event", "Owner", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "OrganiserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Event", "Organiser_OrganiserId", "dbo.Organisers");
            DropIndex("dbo.Event", new[] { "Organiser_OrganiserId" });
            AlterColumn("dbo.EventCategory", "Name", c => c.String());
            AlterColumn("dbo.Event", "Details", c => c.String());
            AlterColumn("dbo.Event", "Name", c => c.String());
            AlterColumn("dbo.Location", "Name", c => c.String());
            DropColumn("dbo.EventCategory", "Icon");
            DropColumn("dbo.EventCategory", "Free");
            DropColumn("dbo.Event", "Organiser_OrganiserId");
            DropColumn("dbo.Location", "County");
            DropColumn("dbo.Location", "Town");
        }
    }
}
