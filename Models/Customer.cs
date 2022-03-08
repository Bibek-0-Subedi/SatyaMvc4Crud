using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SatyaMvc4Crud.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        
        [Required(ErrorMessage = "Enter Your Name")]
        [StringLength(4, ErrorMessage = "Name should be less than or equal to four characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Your Address")]
        [StringLength(10, ErrorMessage = "Address should be less than or euql to ten characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?[0-9]{3})\)?[-.]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Mobileno { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter your date of birth")]
        [DisplayFormat(DataFormatString = "{0:MM/DD/YYYY}", ApplyFormatInEditMode = true)]
        [SatyaMvc4Crud.Models.CustomValidationAttributeDemo.ValidBirthDate(ErrorMessage = "Birth date can not be greater than current date")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Enter your EmailID")]
        [RegularExpression(@"^[\w\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}", ErrorMessage = "Please enter a valid email address")]
        public string EmailID { get; set; }
        public List<Customer> ShowallCustomer { get; set; }
    }

    
}