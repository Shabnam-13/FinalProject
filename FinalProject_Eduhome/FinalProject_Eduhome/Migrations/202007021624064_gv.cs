namespace FinalProject_Eduhome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gv : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Admins", newName: "EduAdmins");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.EduAdmins", newName: "Admins");
        }
    }
}
