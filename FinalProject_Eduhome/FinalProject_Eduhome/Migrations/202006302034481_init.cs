namespace FinalProject_Eduhome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Content = c.String(nullable: false, maxLength: 1000),
                        VideoLink = c.String(maxLength: 250),
                        Copyright = c.String(nullable: false, maxLength: 50),
                        Logo = c.String(maxLength: 250),
                        LogoWhite = c.String(maxLength: 250),
                        Image = c.String(maxLength: 250),
                        BgImage = c.String(maxLength: 250),
                        PrllxImage = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Surname = c.String(nullable: false, maxLength: 20),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 250),
                        Image = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Content = c.String(nullable: false, maxLength: 1000),
                        Author = c.String(nullable: false, maxLength: 50),
                        Read = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Image = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false, maxLength: 500),
                        About = c.String(nullable: false, maxLength: 500),
                        Apply = c.String(nullable: false, maxLength: 500),
                        Certification = c.String(nullable: false, maxLength: 500),
                        Image = c.String(maxLength: 250),
                        StartDate = c.String(nullable: false, maxLength: 20),
                        Duration = c.String(nullable: false, maxLength: 10),
                        ClassDuration = c.String(nullable: false, maxLength: 10),
                        SkillLevel = c.String(nullable: false, maxLength: 25),
                        Language = c.String(nullable: false, maxLength: 20),
                        Students = c.Int(nullable: false),
                        Assessments = c.String(nullable: false, maxLength: 20),
                        Price = c.String(nullable: false, maxLength: 10),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Content = c.String(nullable: false, maxLength: 1000),
                        Image = c.String(maxLength: 250),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.EventInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventDate = c.String(nullable: false, maxLength: 15),
                        EventTime = c.String(nullable: false, maxLength: 20),
                        Venue = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 50),
                        EventId = c.Int(nullable: false),
                        SpeakerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Speakers", t => t.SpeakerId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.SpeakerId);
            
            CreateTable(
                "dbo.Speakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 500),
                        Position = c.String(nullable: false, maxLength: 50),
                        Company = c.String(nullable: false, maxLength: 50),
                        Image = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EduContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 250),
                        Phone1 = c.String(nullable: false, maxLength: 20),
                        Phone2 = c.String(maxLength: 20),
                        Mail = c.String(nullable: false, maxLength: 250),
                        WebSite = c.String(nullable: false, maxLength: 250),
                        MapLink = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EduSocials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IconClass = c.String(nullable: false, maxLength: 50),
                        Link = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50),
                        About = c.String(nullable: false, maxLength: 1000),
                        PositionId = c.Int(nullable: false),
                        Degree = c.String(nullable: false, maxLength: 50),
                        Experience = c.String(nullable: false, maxLength: 25),
                        Hobbies = c.String(nullable: false, maxLength: 250),
                        FacultyId = c.Int(nullable: false),
                        Image = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.PositionId)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.TeachContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mail = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Skype = c.String(maxLength: 50),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeachSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Progress = c.String(nullable: false, maxLength: 5),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.TeachSocials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IconClass = c.String(nullable: false, maxLength: 50),
                        Link = c.String(nullable: false, maxLength: 250),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 250),
                        Subject = c.String(maxLength: 250),
                        Content = c.String(nullable: false, maxLength: 1000),
                        SendDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Slides",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Subtitle = c.String(nullable: false, maxLength: 250),
                        Image = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscribes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 250),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50),
                        Comment = c.String(nullable: false, maxLength: 500),
                        Position = c.String(nullable: false, maxLength: 50),
                        Faculty = c.String(nullable: false, maxLength: 50),
                        Image = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Surname = c.String(nullable: false, maxLength: 20),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 250),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeachSocials", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeachSkills", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Teachers", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.TeachContacts", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.EventInfoes", "SpeakerId", "dbo.Speakers");
            DropForeignKey("dbo.EventInfoes", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Blogs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.TeachSocials", new[] { "TeacherId" });
            DropIndex("dbo.TeachSkills", new[] { "TeacherId" });
            DropIndex("dbo.TeachContacts", new[] { "TeacherId" });
            DropIndex("dbo.Teachers", new[] { "FacultyId" });
            DropIndex("dbo.Teachers", new[] { "PositionId" });
            DropIndex("dbo.EventInfoes", new[] { "SpeakerId" });
            DropIndex("dbo.EventInfoes", new[] { "EventId" });
            DropIndex("dbo.Events", new[] { "CategoryId" });
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropIndex("dbo.Blogs", new[] { "CategoryId" });
            DropTable("dbo.Users");
            DropTable("dbo.Testimonials");
            DropTable("dbo.Subscribes");
            DropTable("dbo.Slides");
            DropTable("dbo.Messages");
            DropTable("dbo.TeachSocials");
            DropTable("dbo.TeachSkills");
            DropTable("dbo.Positions");
            DropTable("dbo.TeachContacts");
            DropTable("dbo.Teachers");
            DropTable("dbo.Faculties");
            DropTable("dbo.EduSocials");
            DropTable("dbo.EduContacts");
            DropTable("dbo.Speakers");
            DropTable("dbo.EventInfoes");
            DropTable("dbo.Events");
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
            DropTable("dbo.Blogs");
            DropTable("dbo.Admins");
            DropTable("dbo.Abouts");
        }
    }
}
