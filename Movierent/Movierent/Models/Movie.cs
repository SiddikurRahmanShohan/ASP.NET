using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movierent.Models
{
    public class Movie
    {
        public int Id {  get; set;}
        [Required]
        public string Name { get; set;}
    }
}