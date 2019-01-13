namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listInFrienreq : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "ApplicationUser_Id" });
            CreateTable(
                "dbo.ApplicationUserApplicationUsers",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id1 = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.ApplicationUser_Id1 })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id1)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id1);
            
            AddColumn("dbo.AspNetUsers", "PendingFriendRequests_FriendId", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "PendingFriendRequests_UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", new[] { "PendingFriendRequests_FriendId", "PendingFriendRequests_UserId" });
            AddForeignKey("dbo.AspNetUsers", new[] { "PendingFriendRequests_FriendId", "PendingFriendRequests_UserId" }, "dbo.PendingFriendRequests", new[] { "FriendId", "UserId" });
            DropColumn("dbo.AspNetUsers", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.AspNetUsers", new[] { "PendingFriendRequests_FriendId", "PendingFriendRequests_UserId" }, "dbo.PendingFriendRequests");
            DropForeignKey("dbo.ApplicationUserApplicationUsers", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserApplicationUsers", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.ApplicationUserApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "PendingFriendRequests_FriendId", "PendingFriendRequests_UserId" });
            DropColumn("dbo.AspNetUsers", "PendingFriendRequests_UserId");
            DropColumn("dbo.AspNetUsers", "PendingFriendRequests_FriendId");
            DropTable("dbo.ApplicationUserApplicationUsers");
            CreateIndex("dbo.AspNetUsers", "ApplicationUser_Id");
            AddForeignKey("dbo.AspNetUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
