namespace CMS.Migrations.CMSContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateeventcategory : DbMigration
    {
        public override void Up()
        {
            //Manually updated db

            //DropForeignKey("dbo.Event", "EventCatId", "dbo.EventCategory");
            //RenameColumn(table: "dbo.Event", name: "EventCatId", newName: "EventCategoryId");
            //RenameIndex(table: "dbo.Event", name: "IX_EventCatId", newName: "IX_EventCategoryId");
            //DropPrimaryKey("dbo.EventCategory");
            //AddColumn("dbo.EventCategory", "EventCategoryId", c => c.Int(nullable: false, identity: true));
            //AddPrimaryKey("dbo.EventCategory", "EventCategoryId");
            //AddForeignKey("dbo.Event", "EventCategoryId", "dbo.EventCategory", "EventCategoryId", cascadeDelete: true);
            //DropColumn("dbo.EventCategory", "EventCatId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.EventCategory", "EventCatId", c => c.Int(nullable: false, identity: true));
            //DropForeignKey("dbo.Event", "EventCategoryId", "dbo.EventCategory");
            //DropPrimaryKey("dbo.EventCategory");
            //DropColumn("dbo.EventCategory", "EventCategoryId");
            //AddPrimaryKey("dbo.EventCategory", "EventCatId");
            //RenameIndex(table: "dbo.Event", name: "IX_EventCategoryId", newName: "IX_EventCatId");
            //RenameColumn(table: "dbo.Event", name: "EventCategoryId", newName: "EventCatId");
            //AddForeignKey("dbo.Event", "EventCatId", "dbo.EventCategory", "EventCatId", cascadeDelete: true);
        }
    }
}
