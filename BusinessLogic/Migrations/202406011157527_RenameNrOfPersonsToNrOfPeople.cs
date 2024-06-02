using BusinessLogic.DBModel.Seed;
using System.Data.Entity.Migrations;
using System.Linq;

public partial class RenameNrOfPersonsToNrIfPeople : DbMigration
{
    public override void Up()
    {
        // Ensure there is no existing column named NrIfPeople
        if (ColumnExists("dbo.DestDbTables", "NrIfPeople"))
        {
            DropColumn("dbo.DestDbTables", "NrIfPeople");
        }

        RenameColumn("dbo.DestDbTables", "NrOfPersons", "NrIfPeople");
    }

    public override void Down()
    {
        RenameColumn("dbo.DestDbTables", "NrIfPeople", "NrOfPersons");
    }

    private bool ColumnExists(string tableName, string columnName)
    {
        using (var context = new DestinationContext())
        {
            var sql = $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}' AND COLUMN_NAME = '{columnName}'";
            var count = context.Database.SqlQuery<int>(sql).Single();
            return count > 0;
        }
    }
}
