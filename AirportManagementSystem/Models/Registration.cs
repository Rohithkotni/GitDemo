using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AirportManagementSystem.Models
{
    [Table("Registration_tbl")]
    public class Registration
    {

        [Key]
        [Required(ErrorMessage ="EmployeeId is Required")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "FirstName is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Gender is Required")]
        public  GenderType? Gender { get; set; }
       
        public enum GenderType
        {
            Male = 1,
            Female = 2,
            Others = 3 
        }

        [Required(ErrorMessage = "DOB is Required")]
        [MinimumAgeCheck(18, ErrorMessage = "Age must be someone at least 18 years of age")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DOB { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                    ErrorMessage = "Entered phone format is not valid.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 6 and 255 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

      
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 6 and 255 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Designation is Required")]

        public string Designation { get; set; }

       
        

        [Required(ErrorMessage = "SecurityQuestion1 is Required")]
        public string SecurityQuestion1 { get; set; }

        [Required(ErrorMessage = "SecurityQuestion2 is Required")]
        public string SecurityQuestion2 { get; set; }

        [Required(ErrorMessage = "SecurityQuestion3 is Required")]
        public string SecurityQuestion3 { get; set; }


        [DefaultValue("false")]
        public bool Active { get; set; }


        

    }

    internal class MinimumAgeCheckAttribute : ValidationAttribute
    {
        int _minimumAge;

        public MinimumAgeCheckAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        public override bool IsValid(object value)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                return date.AddYears(_minimumAge) < DateTime.Now;
            }
            else
            {
                return false;
            }


        }
    }
}