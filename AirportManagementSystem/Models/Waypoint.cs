using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using AirportManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace AirportManagementSystem.Models
{
    [Table("Waypoint_tbl")]
    public class Waypoint
    {

        [Key]
        [Required]
        public int ID { get; set; }
        [Required(ErrorMessage = "Please Provide Waypoint Id")]
        public int WaypointId { get; set; }

        [Required(ErrorMessage = "Please Provide Waypoint Longitude")]
        public decimal Latitude { get; set; }

        [Required(ErrorMessage = "Please Provide Waypoint Longitude")]
        public decimal Longitude { get; set; }

        [Required(ErrorMessage = "Please Provide Speed")]
        public float Speed { get; set; }

        [Required(ErrorMessage = "Please Provide Altitude Value")]
        public int Altitude { get; set; }

        //[ForeignKey("FlightPlanId")]
        //public int FlightPlanId { get; set; }

        //public int FlightPlanId { get; set; }

        //[ForeignKey("FlightPlanId")]

        //[ForeignKey("FlightPlans")]
        //public int FlightPlanId { get; set; }
        //public virtual FlightPlan FlightPlans { get; set; }



    }
}