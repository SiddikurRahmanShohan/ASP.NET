using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movierent.Models;

namespace Movierent.ViewModels
{
    public class RentedViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}