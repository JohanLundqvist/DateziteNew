namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class printingListOfFriends : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserApplicationUsers", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", new[] { "Friends_FriendId", "Friends_UserId" }, "dbo.Friends");
            DropIndex("dbo.AspNetUsers", new[] { "Friends_FriendId", "Friends_UserId" });
            DropIndex("dbo.ApplicationUserApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserApplicationUsers", new[] { "ApplicationUser_Id1" });
            AddColumn("dbo.AspNetUsers", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "ApplicationUser_Id2", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "ApplicationUser_Id");
            CreateIndex("dbo.AspNetUsers", "ApplicationUser_Id1");
            CreateIndex("dbo.AspNetUsers", "ApplicationUser_Id2");
            AddForeignKey("dbo.AspNetUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "ApplicationUser_Id2", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "Friends_FriendId");
            DropColumn("dbo.AspNetUsers", "Friends_UserId");
            DropTable("dbo.ApplicationUserApplicationUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserApplicationUsers",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id1 = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.ApplicationUser_Id1 });
            
            AddColumn("dbo.AspNetUsers", "Friends_UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Friends_FriendId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.AspNetUsers", "ApplicationUser_Id2", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "ApplicationUser_Id2" });
            DropIndex("dbo.AspNetUsers", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.AspNetUsers", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "ApplicationUser_Id2");
            DropColumn("dbo.AspNetUsers", "ApplicationUser_Id1");
            DropColumn("dbo.AspNetUsers", "ApplicationUser_Id");
            CreateIndex("dbo.ApplicationUserApplicationUsers", "ApplicationUser_Id1");
            CreateIndex("dbo.ApplicationUserApplicationUsers", "ApplicationUser_Id");
            CreateIndex("dbo.AspNetUsers", new[] { "Friends_FriendId", "Friends_UserId" });
            AddForeignKey("dbo.AspNetUsers", new[] { "Friends_FriendId", "Friends_UserId" }, "dbo.Friends", new[] { "FriendId", "UserId" });
            AddForeignKey("dbo.ApplicationUserApplicationUsers", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ApplicationUserApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
