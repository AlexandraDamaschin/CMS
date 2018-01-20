namespace CMS.Migrations.CMSContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddevicemodelname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Device", "Name", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Device", "HasError", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Device", "HasError");
            DropColumn("dbo.Device", "Name");
        }
    }
}
