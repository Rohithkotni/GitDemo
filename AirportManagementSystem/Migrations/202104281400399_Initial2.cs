namespace AirportManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FlightPlan_tbl", "Destination", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FlightPlan_tbl", "Destination");
        }
    }
}
