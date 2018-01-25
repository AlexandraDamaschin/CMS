namespace CMS.Migrations.CMSContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "Priority", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "Details", c => c.String());
            AddColumn("dbo.Event", "Owner", c => c.Int(nullable: false));
            AddColumn("dbo.EventCategory", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventCategory", "ImageUrl");
            DropColumn("dbo.Event", "Owner");
            DropColumn("dbo.Event", "Details");
            DropColumn("dbo.Event", "Priority");
        }
    }
}
