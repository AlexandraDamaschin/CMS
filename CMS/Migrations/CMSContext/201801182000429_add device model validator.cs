namespace CMS.Migrations.CMSContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddevicemodelvalidator : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Device", "Build", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Device", "Build", c => c.Int(nullable: false));
        }
    }
}
