namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vetejvadDetÄr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Interests", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Interests", "Name", c => c.String(nullable: false));
        }
    }
}
