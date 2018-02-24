namespace CMS.Migrations.CMSContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeeventcategoryicon : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.EventCategory", "Icon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventCategory", "Icon", c => c.String());
        }
    }
}
