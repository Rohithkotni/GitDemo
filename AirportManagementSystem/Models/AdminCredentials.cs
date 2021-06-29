using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportManagementSystem.Models
{
    [Table("AdminCredentials_tbl")]
    public class AdminCredentials
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string AdminId { get; set; }

        [Required]
        public string UserName { get; set; }

        
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}