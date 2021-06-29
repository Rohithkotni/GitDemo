using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirportManagementSystem.Models
{
    [Table("ManagerCredentials_tbl")]
    public class ManagerCredentials
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public int ManagerId { get; set; }

        [Required]
        public string Designation { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}