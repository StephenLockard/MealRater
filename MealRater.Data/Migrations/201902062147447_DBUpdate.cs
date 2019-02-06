namespace MealRater.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meal", "MealDescription", c => c.String(nullable: false));
            DropColumn("dbo.Meal", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meal", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Meal", "MealDescription");
        }
    }
}
