namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserUsers",
                c => new
                    {
                        User_ID = c.Int(nullable: false),
                        User_ID1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_ID, t.User_ID1 })
                .ForeignKey("dbo.Users", t => t.User_ID)
                .ForeignKey("dbo.Users", t => t.User_ID1)
                .Index(t => t.User_ID)
                .Index(t => t.User_ID1);
            
            DropColumn("dbo.Users", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Email", c => c.String());
            DropForeignKey("dbo.UserUsers", "User_ID1", "dbo.Users");
            DropForeignKey("dbo.UserUsers", "User_ID", "dbo.Users");
            DropIndex("dbo.UserUsers", new[] { "User_ID1" });
            DropIndex("dbo.UserUsers", new[] { "User_ID" });
            DropTable("dbo.UserUsers");
        }
    }
}
