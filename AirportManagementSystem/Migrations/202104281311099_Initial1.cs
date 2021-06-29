namespace AirportManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FlightPlan_tbl", "WayPoint1", c => c.Int(nullable: false));
            AddColumn("dbo.FlightPlan_tbl", "WayPoint2", c => c.Int(nullable: false));
            DropColumn("dbo.FlightPlan_tbl", "WayPointId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FlightPlan_tbl", "WayPointId", c => c.Int(nullable: false));
            DropColumn("dbo.FlightPlan_tbl", "WayPoint2");
            DropColumn("dbo.FlightPlan_tbl", "WayPoint1");
        }
    }
}
