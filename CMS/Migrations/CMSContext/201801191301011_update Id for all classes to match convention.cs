namespace CMS.Migrations.CMSContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateIdforallclassestomatchconvention : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Device", new[] { "LocationID" });
            DropIndex("dbo.Event", new[] { "EventCatID" });
            DropIndex("dbo.Event", new[] { "LocationID" });
            CreateIndex("dbo.Device", "LocationId");
            CreateIndex("dbo.Event", "EventCatId");
            CreateIndex("dbo.Event", "LocationId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Event", new[] { "LocationId" });
            DropIndex("dbo.Event", new[] { "EventCatId" });
            DropIndex("dbo.Device", new[] { "LocationId" });
            CreateIndex("dbo.Event", "LocationID");
            CreateIndex("dbo.Event", "EventCatID");
            CreateIndex("dbo.Device", "LocationID");
        }
    }
}
