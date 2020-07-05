namespace FinalProject_Eduhome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventDate", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Events", "EventTime", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Events", "Venue", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Events", "City", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.EventInfoes", "EventDate");
            DropColumn("dbo.EventInfoes", "EventTime");
            DropColumn("dbo.EventInfoes", "Venue");
            DropColumn("dbo.EventInfoes", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventInfoes", "City", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.EventInfoes", "Venue", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.EventInfoes", "EventTime", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.EventInfoes", "EventDate", c => c.String(nullable: false, maxLength: 15));
            DropColumn("dbo.Events", "City");
            DropColumn("dbo.Events", "Venue");
            DropColumn("dbo.Events", "EventTime");
            DropColumn("dbo.Events", "EventDate");
        }
    }
}
