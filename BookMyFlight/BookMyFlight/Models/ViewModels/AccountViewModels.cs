using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookMyFlight.Models.ViewModels
{
    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class AirlineRegisterViewModel
    {
        [Required]
        [Display(Name = "Agency Name")]
        public string airline_name { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string airline_address { get; set; }

        [Required]
        [Display(Name = "Phone No")]
        public string airline_phone { get; set; }

        [Required]
        [Display(Name = "Registration No")]
        public string airline_regno { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required]
        [Display(Name = "Account Recovery Phone")]
        public string recovery_phone { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
    public class CustomerRegisterViewModel
    {
        [Required]
        [Display(Name = "First name")]
        public string cust_first_name { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string cust_last_name { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string cust_address { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string cust_gender { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public System.DateTime cust_dob { get; set; }

        [Required]
        [Display(Name = "Occupation")]
        public string cust_occupation { get; set; }

        [Required]
        [Display(Name = "Blood Group")]
        public string cust_blood_group { get; set; }

        [Required]
        [Display(Name = "Phone No")]
        public string customer_cell { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required]
        [Display(Name = "Account Recovery Phone")]
        public string recovery_phone { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}