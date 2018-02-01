namespace CMS.Migrations.CMSContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tagtbladded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.TagEvents",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Event_EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Event_EventId })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Event", t => t.Event_EventId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Event_EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagEvents", "Event_EventId", "dbo.Event");
            DropForeignKey("dbo.TagEvents", "Tag_TagId", "dbo.Tags");
            DropIndex("dbo.TagEvents", new[] { "Event_EventId" });
            DropIndex("dbo.TagEvents", new[] { "Tag_TagId" });
            DropTable("dbo.TagEvents");
            DropTable("dbo.Tags");
        }
    }
}
