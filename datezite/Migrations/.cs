namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tesa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PendingFriendRequests",
                c => new
                {
                    FriendId = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.FriendId, t.UserId });
        }
        
        public override void Down()
        {
        }
    }
}
