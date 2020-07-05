namespace FinalProject_Eduhome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventDay", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Events", "EventMonth", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Events", "EventYear", c => c.String(nullable: false, maxLength: 15));
            DropColumn("dbo.Events", "EventDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EventDate", c => c.String(nullable: false, maxLength: 15));
            DropColumn("dbo.Events", "EventYear");
            DropColumn("dbo.Events", "EventMonth");
            DropColumn("dbo.Events", "EventDay");
        }
    }
}
