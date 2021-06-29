using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirportManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace AirportManagementSystem.Models
{
    [Table("PreCheckList_tbl")]
    public class PreCheckList
    {

        [Key]
        [Required]
        public int ID { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"^\d+$")]
        public int PreCheckId { get; set; }
       
        [Required]

        public string Power { get; set; }
       

        [Required]

        public string BatteryVoltage { get; set; }
        
        

        [Required]

        public string BatteryCables { get; set; }
        

        [Required]


        public string HomeAltitude { get; set; }
        

        [Required]


        public string FlightPlan { get; set; }

        [Required]


        public string GPS { get; set; }


        [Required]

        public string Antenna { get; set; }



        [Required]

        public string Speed { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"^\d+$")]
        public int YourPlaneId { get; set; }
      
        


       
    }
}