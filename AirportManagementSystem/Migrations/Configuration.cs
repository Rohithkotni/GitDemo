namespace AirportManagementSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AirportManagementSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AirportManagementSystem.Models.AirportManagementSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AirportManagementSystem.Models.AirportManagementSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.AdminCredentials.AddOrUpdate(s => s.ID,
                new AdminCredentials { AdminId ="Admin",UserName="Admin",Password="admin123"});
        }
    }
}
