namespace CMS.Migrations.CMSContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateLongtoLngtomatchconvention : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Location", "Lng", c => c.Single(nullable: false));
            DropColumn("dbo.Location", "Long");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Location", "Long", c => c.Single(nullable: false));
            DropColumn("dbo.Location", "Lng");
        }
    }
}
