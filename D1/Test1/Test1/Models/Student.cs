using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test1.Models
{
    public class Student
    {
        [Required]
        [RegularExpression(@"^[0-9]{2}-[0-9]{5}-[1-3]{1}$", ErrorMessage="Must be xx-xxxxx-x")]
        public string Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The Name must not exceed 20 charecter!")]
        public string Name { get; set; }
        [Required]
        public string Dob { get; set; }
    }
}