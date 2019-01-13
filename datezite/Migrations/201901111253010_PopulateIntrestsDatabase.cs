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
            Sql("INSERT INTO AspNetUsers VALUES(1, 'testing@hotmail.com', 1, null,null, null, 0, 0, null, 0, 0, 'testing@hotmail.com', 'testing@hotmail.com', 'Man', 'Ulrik', 'Hedman', 25, null, 'Pluggar systemvetare',null)");
            Sql("INSERT INTO AspNetUsers VALUES(2, 'hejsvejs@hotmail.com.com', 1, null,null, null, 0, 0, null, 0, 0, 'hejsvejs@hotmail.com', 'hejsvejs@hotmail.com', 'Kvinna', 'Ulrika', 'Cederberg', 25, null, 'VD för Astrazeneca', null)");
        }
        
        public override void Down()
        {
        }
    }
}
