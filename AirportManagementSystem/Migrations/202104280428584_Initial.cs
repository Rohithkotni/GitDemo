namespace AirportManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminCredentials_tbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdminId = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FlightPlan_tbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FlightPlanId = c.Int(nullable: false),
                        DepartureLocation = c.String(nullable: false),
                        EDA = c.DateTime(nullable: false),
                        ETA = c.DateTime(nullable: false),
                        AlternateAirports = c.String(nullable: false),
                        WayPointId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Hangar_tbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HangarId = c.Int(nullable: false),
                        HangarSize = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                        PlaneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Help_tbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IssueId = c.Int(nullable: false),
                        IssueName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ManagerCredentials_tbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ManagerId = c.Int(nullable: false),
                        Designation = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PilotCredentials_tbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PilotId = c.Int(nullable: false),
                        Designation = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Plane_tbl",
                c => new
                    {
                        PlaneId = c.Int(nullable: false, identity: true),
                        ModelNumber = c.String(nullable: false, maxLength: 15),
                        PurchaseDate = c.DateTime(nullable: false),
                        LastServicedDate = c.DateTime(nullable: false),
                        PlaneStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PlaneId);
            
            CreateTable(
                "dbo.PostCheckList_tbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostCheckId = c.Int(nullable: false),
                        Transponder = c.String(nullable: false),
                        WingFlaps = c.String(nullable: false),
                        CarbHeat = c.String(nullable: false),
                        Lights = c.String(nullable: false),
                        Trim = c.String(nullable: false),
                        Mixture = c.String(nullable: false),
                        YourPlaneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PreCheckList_tbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PreCheckId = c.Int(nullable: false),
                        Power = c.String(nullable: false),
                        BatteryVoltage = c.String(nullable: false),
                        BatteryCables = c.String(nullable: false),
                        HomeAltitude = c.String(nullable: false),
                        FlightPlan = c.String(nullable: false),
                        GPS = c.String(nullable: false),
                        Antenna = c.String(nullable: false),
                        Speed = c.String(nullable: false),
                        YourPlaneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Registration_tbl",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        ContactNumber = c.Long(nullable: false),
                        Password = c.String(nullable: false, maxLength: 255),
                        ConfirmPassword = c.String(nullable: false, maxLength: 255),
                        Designation = c.String(nullable: false),
                        SecurityQuestion1 = c.String(nullable: false),
                        SecurityQuestion2 = c.String(nullable: false),
                        SecurityQuestion3 = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Schedule_tbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ScheduleId = c.Int(nullable: false),
                        ScheduleDate = c.DateTime(nullable: false),
                        ScheduleTime = c.DateTime(nullable: false),
                        AllocatedPlaneId = c.Int(nullable: false),
                        AllocatedPilotId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Waypoint_tbl",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WaypointId = c.Int(nullable: false),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Speed = c.Single(nullable: false),
                        Altitude = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Waypoint_tbl");
            DropTable("dbo.Schedule_tbl");
            DropTable("dbo.Registration_tbl");
            DropTable("dbo.PreCheckList_tbl");
            DropTable("dbo.PostCheckList_tbl");
            DropTable("dbo.Plane_tbl");
            DropTable("dbo.PilotCredentials_tbl");
            DropTable("dbo.ManagerCredentials_tbl");
            DropTable("dbo.Help_tbl");
            DropTable("dbo.Hangar_tbl");
            DropTable("dbo.FlightPlan_tbl");
            DropTable("dbo.AdminCredentials_tbl");
        }
    }
}
