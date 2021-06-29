using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirportManagementSystem.Models
{
    [Table("PilotCredentials_tbl")]
    public class PilotCredentials
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public int PilotId { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}