namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ok : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "User_ID", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_ID" });
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Hobbies = c.String(),
                        Age = c.Int(nullable: false),
                        Work = c.String(),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        GenderOfMember = c.Int(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Users", "User_ID");
            AddForeignKey("dbo.Users", "User_ID", "dbo.Users", "ID");
        }
    }
}
