namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameNrOfPersonsToNrIfPeople : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DestDbTables", "NrOfPeople", c => c.Int(nullable: false));
            DropColumn("dbo.DestDbTables", "NrOfPersons");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DestDbTables", "NrOfPersons", c => c.Int(nullable: false));
            DropColumn("dbo.DestDbTables", "NrOfPeople");
        }
    }
}
