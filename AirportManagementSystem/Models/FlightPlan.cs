using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using AirportManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
namespace AirportManagementSystem.Models
{
    [Table("FlightPlan_tbl")]
    public class FlightPlan
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"^\d+$")]
        public int FlightPlanId { get; set; }

        [Required(ErrorMessage = "Please provide Departure Location")]
        public string DepartureLocation { get; set; }

        [Required(ErrorMessage = "Please Provide Valid EDA")]
        [DataType(DataType.DateTime)]
 
        public DateTime? EDA { get; set; }

        [Required(ErrorMessage = "Please Provide Valid ETA")]

        [DataType(DataType.Time)]
        public DateTime ETA { get; set; }

        [Required(ErrorMessage = "Please Provide Destination")]
        public string Destination { get; set; }

        [Required(ErrorMessage = "Please provide Alternate Airports")]
        public string AlternateAirports { get; set; }

        [RegularExpression(@"^\d+$")]
        public int WayPoint1 { get; set; }

        [RegularExpression(@"^\d+$")]
        public int WayPoint2 { get; set; }

       



    }


}