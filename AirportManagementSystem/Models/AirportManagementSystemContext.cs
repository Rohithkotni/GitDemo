using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AirportManagementSystem.Models
{
    public class AirportManagementSystemContext : DbContext
    {
        public AirportManagementSystemContext() : base("AirportManagementSystemDB")
        {
                
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Waypoint>()
            //    .HasOptional(f => f.FlightPlans)
            //    .WithRequired(w => w.Waypoints);
                
        }

        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Plane> Planes { get; set; }

        public DbSet<AdminCredentials> AdminCredentials { get; set; }

        public DbSet<ManagerCredentials> ManagerCredentials { get; set; }
        public DbSet<PilotCredentials> PilotCredentials { get; set; }

        public DbSet<FlightPlan> FlightPlans { get; set; }

        public DbSet<Waypoint> Waypoints { get; set; }

        public DbSet<Hangar> Hangers { get; set; }
        public DbSet<Help> Help { get; set; }
       

        public DbSet<PreCheckList> PreCheckLists { get; set; }
        public DbSet<PostCheckList> PostCheckLists { get; set; }

        public DbSet<Schedule> Schedules { get; set; }



       
    }
}