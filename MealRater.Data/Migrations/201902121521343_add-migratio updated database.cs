namespace MealRater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigratioupdateddatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MealVote", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MealVote", "CreatedUtc");
        }
    }
}
