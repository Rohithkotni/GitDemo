using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using AirportManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AirportManagementSystem.Models
{
    [Table("Hangar_tbl")]
    public class Hangar
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"^\d+$")]
        public int HangarId { get; set; }

        [Required(ErrorMessage = "Please provide Hangar Size")]
        public double HangarSize { get; set; }

        [Required(ErrorMessage = "Please provide Status")]
        [DefaultValue("false")]

        public bool Status { get; set; }

        [RegularExpression(@"^\d+$")]
        public int PlaneId { get; set; }


        //[ForeignKey("ManagerId")]
        //public int ManagerId { get; set; }


        //public virtual ICollection<Plane> Planes { get; set; }


        //[ForeignKey("Registrations")]
        //public int ManagerId { get; set; }

        //public virtual Registration Registrations { get; set; }





    }
}