namespace FinalProject_Eduhome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jk : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Subscribes", "Page");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subscribes", "Page", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
