namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserUsers", "User_ID", "dbo.Users");
            DropForeignKey("dbo.UserUsers", "User_ID1", "dbo.Users");
            DropIndex("dbo.UserUsers", new[] { "User_ID" });
            DropIndex("dbo.UserUsers", new[] { "User_ID1" });
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Author_Id = c.String(maxLength: 128),
                        Recipient_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Recipient_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Recipient_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.Users", "User_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Användarnamn", c => c.String());
            AddColumn("dbo.AspNetUsers", "Kön", c => c.String());
            AddColumn("dbo.AspNetUsers", "Förnamn", c => c.String());
            AddColumn("dbo.AspNetUsers", "Efternamn", c => c.String());
            AddColumn("dbo.AspNetUsers", "Ålder", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Lösenord", c => c.String());
            AddColumn("dbo.AspNetUsers", "Sysselsättning", c => c.String());
            AddColumn("dbo.AspNetUsers", "Intressen", c => c.String());
            AddColumn("dbo.AspNetUsers", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Users", "User_ID");
            CreateIndex("dbo.AspNetUsers", "ApplicationUser_Id");
            AddForeignKey("dbo.Users", "User_ID", "dbo.Users", "ID");
            AddForeignKey("dbo.AspNetUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropTable("dbo.UserUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserUsers",
                c => new
                    {
                        User_ID = c.Int(nullable: false),
                        User_ID1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_ID, t.User_ID1 });
            
            DropForeignKey("dbo.AspNetUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Entries", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Entries", "Recipient_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Entries", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Users", "User_ID", "dbo.Users");
            DropIndex("dbo.Entries", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Entries", new[] { "Recipient_Id" });
            DropIndex("dbo.Entries", new[] { "Author_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Users", new[] { "User_ID" });
            DropColumn("dbo.AspNetUsers", "ApplicationUser_Id");
            DropColumn("dbo.AspNetUsers", "Intressen");
            DropColumn("dbo.AspNetUsers", "Sysselsättning");
            DropColumn("dbo.AspNetUsers", "Lösenord");
            DropColumn("dbo.AspNetUsers", "Ålder");
            DropColumn("dbo.AspNetUsers", "Efternamn");
            DropColumn("dbo.AspNetUsers", "Förnamn");
            DropColumn("dbo.AspNetUsers", "Kön");
            DropColumn("dbo.AspNetUsers", "Användarnamn");
            DropColumn("dbo.Users", "User_ID");
            DropTable("dbo.Entries");
            CreateIndex("dbo.UserUsers", "User_ID1");
            CreateIndex("dbo.UserUsers", "User_ID");
            AddForeignKey("dbo.UserUsers", "User_ID1", "dbo.Users", "ID");
            AddForeignKey("dbo.UserUsers", "User_ID", "dbo.Users", "ID");
        }
    }
}
