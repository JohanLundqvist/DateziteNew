namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class användarintressen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        InterestID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.InterestID);
            
            CreateTable(
                "dbo.InterestsApplicationUsers",
                c => new
                    {
                        Interests_InterestID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Interests_InterestID, t.ApplicationUser_Id })
                .ForeignKey("dbo.Interests", t => t.Interests_InterestID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Interests_InterestID)
                .Index(t => t.ApplicationUser_Id);
            
            DropColumn("dbo.AspNetUsers", "Intressen");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Intressen", c => c.String());
            DropForeignKey("dbo.InterestsApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.InterestsApplicationUsers", "Interests_InterestID", "dbo.Interests");
            DropIndex("dbo.InterestsApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.InterestsApplicationUsers", new[] { "Interests_InterestID" });
            DropTable("dbo.InterestsApplicationUsers");
            DropTable("dbo.Interests");
        }
    }
}
