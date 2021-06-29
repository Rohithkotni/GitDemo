using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using AirportManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace AirportManagementSystem.Models
{
    [Table("Schedule_tbl")]
    public class Schedule
    {

        [Key]
        [Required]
        public int ID { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"^\d+$")]
        public int ScheduleId { get; set; }

        [Required(ErrorMessage = "Please Provide Schedule date")]
        [DataType(DataType.Date)]
        public DateTime ScheduleDate { get; set; }


        [Required(ErrorMessage = "Please Provide Schedule time")]
        [DataType(DataType.Time)]
        public DateTime ScheduleTime { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"^\d+$")]
        public int AllocatedPlaneId { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"^\d+$")]
        public int AllocatedPilotId { get; set; }


        //public virtual FlightPlan FlightPlans { get; set; }


        //[ForeignKey("Planes")]
        //public int PlaneId { get; set; }

        //public virtual Plane Planes { get; set; }

        //[ForeignKey("Registrations")]
        //public int PilotId { get; set; }
        //public virtual Registration Registrations { get; set; }

        //public virtual PreCheckList PreCheckLists { get; set; }
        //public virtual PostCheckList PostCheckLists { get; set; }
    }
}