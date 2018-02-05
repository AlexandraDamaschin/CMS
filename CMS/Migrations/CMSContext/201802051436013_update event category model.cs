namespace CMS.Migrations.CMSContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateeventcategorymodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.EventCategory", "Outdoor");
            DropColumn("dbo.EventCategory", "Family");
            DropColumn("dbo.EventCategory", "Free");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventCategory", "Free", c => c.Boolean(nullable: false));
            AddColumn("dbo.EventCategory", "Family", c => c.Boolean(nullable: false));
            AddColumn("dbo.EventCategory", "Outdoor", c => c.Boolean(nullable: false));
        }
    }
}
