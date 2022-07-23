//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookMyFlight.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public Customer()
        {
            this.Logins = new HashSet<Login>();
            this.Tickets = new HashSet<Ticket>();
        }
    
        public int customer_id { get; set; }
        public string cust_first_name { get; set; }
        public string cust_last_name { get; set; }
        public string cust_address { get; set; }
        public string cust_gender { get; set; }
        public System.DateTime cust_dob { get; set; }
        public string cust_occupation { get; set; }
        public string cust_blood_group { get; set; }
        public string customer_cell { get; set; }
        public string customer_status { get; set; }
    
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}