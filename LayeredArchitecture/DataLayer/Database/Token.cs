//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Token
    {
        public int Id { get; set; }
        public string TokenKey { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public int Uid { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
