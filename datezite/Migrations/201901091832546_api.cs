namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class api : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entries", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Entries", "Recipient_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Entries", new[] { "Author_Id" });
            DropIndex("dbo.Entries", new[] { "Recipient_Id" });
            AddColumn("dbo.Entries", "AuthorId", c => c.String());
            AddColumn("dbo.Entries", "RecipientId", c => c.String());
            DropColumn("dbo.Entries", "Author_Id");
            DropColumn("dbo.Entries", "Recipient_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entries", "Recipient_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Entries", "Author_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Entries", "RecipientId");
            DropColumn("dbo.Entries", "AuthorId");
            CreateIndex("dbo.Entries", "Recipient_Id");
            CreateIndex("dbo.Entries", "Author_Id");
            AddForeignKey("dbo.Entries", "Recipient_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Entries", "Author_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
