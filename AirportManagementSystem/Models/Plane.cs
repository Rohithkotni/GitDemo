using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace AirportManagementSystem.Models
{
    [Table("Plane_tbl")]
    public class Plane
    {

        [Key]
        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"^\d+$")]
        public int PlaneId { get; set; }

        [Required(ErrorMessage = "Please Provide Model Number")]
        [MaxLength(15)]
        public string ModelNumber { get; set; }

        [Required(ErrorMessage = "Please Provide Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "Please Provide Last Serviced Date")]
        [DataType(DataType.Date)]
        public DateTime LastServicedDate { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage ="Please Provide the Status")]
        [DefaultValue("false")]
        public bool PlaneStatus { get; set; }
        //public enum StatusofPlane
        //{
        //    Active,
        //    Inactive
        //}

        //public int FlightPlanId { get; set; }

        //[ForeignKey("FlightPlanId")]
        //public virtual FlightPlan FlightPlans { get; set; }

        //public virtual ICollection<FlightPlan> FlightPlans { get; set; }

        //[ForeignKey("Hangers")]
        //public int HangerId { get; set; }
        //public virtual Hangar Hangers { get; set; }

        //public virtual PreCheckList PreCheckLists { get; set; }

        //public virtual PostCheckList PostCheckLists { get; set; }

        //public virtual ICollection<Schedule> Schedules { get; set; }

        //[ForeignKey("Registrations")]
        //public int ManagerId { get; set; }

        //public virtual Registration Registrations { get; set; }

        //[ForeignKey("Hangars")]
        //public int HangarId { get; set; }
        //public virtual Hangar Hangars { get; set; }


        

    }
}