namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DestDbTables",
                c => new
                    {
                        DestinationID = c.Int(nullable: false, identity: true),
                        DestinationName = c.String(nullable: false, maxLength: 30),
                        Country = c.String(nullable: false),
                        City = c.String(),
                        Days = c.Int(nullable: false),
                        NrOfPersons = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Description = c.String(nullable: false),
                        Rating = c.Int(nullable: false),
                        Img = c.Binary(),
                    })
                .PrimaryKey(t => t.DestinationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DestDbTables");
        }
    }
}
