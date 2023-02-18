using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RetailManagment.Models
{
    public class CustomerModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage ="Please enter your first name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter your Last name.")]
        public string LastName { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Please enter a username.")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter your emiail address.")]
        public string EmailAddress { get; set; }

        [Display(Name = "Confirm Email")]
        [Compare("EmailAddress", ErrorMessage = "The Email and Confirm Email must match.")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You must have a password.")]
        [DataType(DataType.Password)]
        [StringLength(60, MinimumLength = 10, ErrorMessage ="You need to provide a long enough password.")]
        public string Password { get; set; }

        [Display(Name = "Confrim Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The Password and Confirm Password must match.")]
        public string ConfirmPassword { get; set; }
    }
}