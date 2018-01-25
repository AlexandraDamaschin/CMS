namespace CMS.Migrations.CMSContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addorganisertoevent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Event", "Organiser_OrganiserId", "dbo.Organisers");
            DropIndex("dbo.Event", new[] { "Organiser_OrganiserId" });
            RenameColumn(table: "dbo.Event", name: "Organiser_OrganiserId", newName: "OrganiserId");
            AlterColumn("dbo.Event", "OrganiserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Event", "OrganiserId");
            AddForeignKey("dbo.Event", "OrganiserId", "dbo.Organisers", "OrganiserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "OrganiserId", "dbo.Organisers");
            DropIndex("dbo.Event", new[] { "OrganiserId" });
            AlterColumn("dbo.Event", "OrganiserId", c => c.Int());
            RenameColumn(table: "dbo.Event", name: "OrganiserId", newName: "Organiser_OrganiserId");
            CreateIndex("dbo.Event", "Organiser_OrganiserId");
            AddForeignKey("dbo.Event", "Organiser_OrganiserId", "dbo.Organisers", "OrganiserId");
        }
    }
}
