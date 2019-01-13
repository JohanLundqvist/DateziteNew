namespace datezite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateIntrestsDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Interests(Name) VALUES('Vapen')");
            Sql("INSERT INTO Interests(Name) VALUES('Gaming')");
            Sql("INSERT INTO Interests(Name) VALUES('Pengar')");
            Sql("INSERT INTO Interests(Name) VALUES('Hälsa')");
            Sql("INSERT INTO Interests(Name) VALUES('Fågelskådning')");
            Sql("INSERT INTO Interests(Name) VALUES('Bilar')");
            Sql("INSERT INTO Interests(Name) VALUES('B-Rudar')");
            Sql("INSERT INTO Interests(Name) VALUES('Flygplan')");
        }
        
        public override void Down()
        {
        }
    }
}
