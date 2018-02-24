namespace CMS.Migrations.CMSContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetags : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TagEvents", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.TagEvents", "Event_EventId", "dbo.Event");
            DropIndex("dbo.TagEvents", new[] { "Tag_TagId" });
            DropIndex("dbo.TagEvents", new[] { "Event_EventId" });
            DropTable("dbo.Tags");
            DropTable("dbo.TagEvents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TagEvents",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Event_EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Event_EventId });
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateIndex("dbo.TagEvents", "Event_EventId");
            CreateIndex("dbo.TagEvents", "Tag_TagId");
            AddForeignKey("dbo.TagEvents", "Event_EventId", "dbo.Event", "EventId", cascadeDelete: true);
            AddForeignKey("dbo.TagEvents", "Tag_TagId", "dbo.Tags", "TagId", cascadeDelete: true);
        }
    }
}
