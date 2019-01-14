namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class regex : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Förnamn", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Efternamn", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Sysselsättning", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Sysselsättning", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Efternamn", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Förnamn", c => c.String());
        }
    }
}
