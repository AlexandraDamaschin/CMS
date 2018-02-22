namespace CMS.Migrations.CMSContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeventvalidatordataannotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Event", "Details", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Event", "Details", c => c.String(maxLength: 255));
        }
    }
}
