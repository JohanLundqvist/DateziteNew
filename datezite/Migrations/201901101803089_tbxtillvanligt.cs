namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbxtillvanligt : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.InterestsApplicationUsers", newName: "ApplicationUserInterests");
            DropPrimaryKey("dbo.ApplicationUserInterests");
            AddPrimaryKey("dbo.ApplicationUserInterests", new[] { "ApplicationUser_Id", "Interests_InterestID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ApplicationUserInterests");
            AddPrimaryKey("dbo.ApplicationUserInterests", new[] { "Interests_InterestID", "ApplicationUser_Id" });
            RenameTable(name: "dbo.ApplicationUserInterests", newName: "InterestsApplicationUsers");
        }
    }
}
