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
    
    public partial class Transit
    {
        public int transit_id { get; set; }
        public int ticket_id { get; set; }
        public int flight_id { get; set; }
        public decimal sub_total { get; set; }
    
        public virtual Flight Flight { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
