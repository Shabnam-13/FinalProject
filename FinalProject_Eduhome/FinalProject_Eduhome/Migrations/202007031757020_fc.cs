namespace FinalProject_Eduhome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Content = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Abouts", "Icon", c => c.String(maxLength: 250));
            AddColumn("dbo.Abouts", "IconWhite", c => c.String(maxLength: 250));
            AddColumn("dbo.Abouts", "VideoImage", c => c.String(maxLength: 250));
            AddColumn("dbo.Abouts", "SidebarImage", c => c.String(maxLength: 250));
            AddColumn("dbo.Messages", "Page", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Subscribes", "Page", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Blogs", "Content", c => c.String(nullable: false));
            DropColumn("dbo.Abouts", "LogoWhite");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "LogoWhite", c => c.String(maxLength: 250));
            AlterColumn("dbo.Blogs", "Content", c => c.String(nullable: false, maxLength: 1000));
            DropColumn("dbo.Subscribes", "Page");
            DropColumn("dbo.Messages", "Page");
            DropColumn("dbo.Abouts", "SidebarImage");
            DropColumn("dbo.Abouts", "VideoImage");
            DropColumn("dbo.Abouts", "IconWhite");
            DropColumn("dbo.Abouts", "Icon");
            DropTable("dbo.Services");
        }
    }
}
