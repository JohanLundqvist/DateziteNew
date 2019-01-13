namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class y : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Friends_FriendId", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Friends_UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", new[] { "Friends_FriendId", "Friends_UserId" });
            AddForeignKey("dbo.AspNetUsers", new[] { "Friends_FriendId", "Friends_UserId" }, "dbo.Friends", new[] { "FriendId", "UserId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", new[] { "Friends_FriendId", "Friends_UserId" }, "dbo.Friends");
            DropIndex("dbo.AspNetUsers", new[] { "Friends_FriendId", "Friends_UserId" });
            DropColumn("dbo.AspNetUsers", "Friends_UserId");
            DropColumn("dbo.AspNetUsers", "Friends_FriendId");
        }
    }
}
