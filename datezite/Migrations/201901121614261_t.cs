namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class t : DbMigration
    {
        public override void Up()
        {
            Sql("Alter Table dbo.aspNetUsers Add UserPhoto varbinary(max)");
        }
        
        public override void Down()
        {
        }
    }
}
