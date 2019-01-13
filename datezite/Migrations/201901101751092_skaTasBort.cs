namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skaTasBort : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationUserInterests", newName: "InterestsApplicationUsers");
            DropPrimaryKey("dbo.InterestsApplicationUsers");
            AddPrimaryKey("dbo.InterestsApplicationUsers", new[] { "Interests_InterestID", "ApplicationUser_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.InterestsApplicationUsers");
            AddPrimaryKey("dbo.InterestsApplicationUsers", new[] { "ApplicationUser_Id", "Interests_InterestID" });
            RenameTable(name: "dbo.InterestsApplicationUsers", newName: "ApplicationUserInterests");
        }
    }
}
