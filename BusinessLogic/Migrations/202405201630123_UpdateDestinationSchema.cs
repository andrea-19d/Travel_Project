namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDestinationSchema : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DestDbTables", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DestDbTables", "Status");
        }
    }
}
