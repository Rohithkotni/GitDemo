using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace AirportManagementSystem.Models
{
    [Table("Help_tbl")]
    public class Help
    {
        [Key]
       
        public int ID { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"^\d+$")]
        public int IssueId { get; set; }

        [Required(ErrorMessage ="Required IssueName")]
        public string IssueName { get; set; }

        [Required(ErrorMessage ="Please Provide Description Of the Issue")]
        public string Description { get; set; }


        public string Answer { get; set; }


    }
}