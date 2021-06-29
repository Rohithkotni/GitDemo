using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AirportManagementSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace AirportManagementSystem.Models
{
    [Table("PostCheckList_tbl")]
    public class PostCheckList
    {

        [Key]
        [Required]
        public int ID { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"^\d+$")]
        public int PostCheckId { get; set; }

        [Required(ErrorMessage = "Please Check the Transponder")]
        
        public string Transponder { get; set; }
        
        [Required(ErrorMessage = "Please Check the Wing Flaps")]
        
        public string WingFlaps { get; set; }
        

        [Required(ErrorMessage = "Please Check Carb Heat")]
        public string CarbHeat { get; set; }
        
        

        [Required(ErrorMessage = "Please Check the Lights")]
        public string Lights { get; set; }
       

        [Required(ErrorMessage = "Please Check the Trim")]
        public string Trim { get; set; }
       

        [Required(ErrorMessage = "Please Check the Mixture")]
        public string Mixture { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"^\d+$")]
        public int YourPlaneId { get; set; }


       

    }
}