using OnlineShop.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.ViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage="Do not Match!")]
        public string ConfirmPassword { get; set; }

    }
}