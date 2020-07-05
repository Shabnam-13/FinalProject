namespace FinalProject_Eduhome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Content", c => c.String(nullable: false, maxLength: 3000));
            DropColumn("dbo.Events", "EventDay");
            DropColumn("dbo.Events", "EventMonth");
            DropColumn("dbo.Events", "EventYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EventYear", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Events", "EventMonth", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Events", "EventDay", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Events", "Content", c => c.String(nullable: false, maxLength: 1000));
        }
    }
}
