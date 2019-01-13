namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "GenderOfMember", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Gender", c => c.String());
            DropColumn("dbo.Users", "GenderOfMember");
        }
    }
}
