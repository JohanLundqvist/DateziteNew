namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteLösenochAnvändarNamn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Användarnamn");
            DropColumn("dbo.AspNetUsers", "Lösenord");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Lösenord", c => c.String());
            AddColumn("dbo.AspNetUsers", "Användarnamn", c => c.String());
        }
    }
}
