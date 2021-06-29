namespace AirportManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial8 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Registration_tbl", "ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Registration_tbl", "ConfirmPassword", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
