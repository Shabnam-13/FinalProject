namespace FinalProject_Eduhome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "Page");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Page", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
