namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class g : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Friends");
            AlterColumn("dbo.Friends", "FriendId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Friends", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Friends", new[] { "FriendId", "UserId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Friends");
            AlterColumn("dbo.Friends", "UserId", c => c.String());
            AlterColumn("dbo.Friends", "FriendId", c => c.String());
        }
    }
}
