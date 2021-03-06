//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineShop.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Product
    {
        public Product()
        {
            this.Cart_Itemes = new HashSet<Cart_Itemes>();
        }
    
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal PurchasePrice { get; set; }
        [Required]
        public decimal SellPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Category { get; set; }
    
        public virtual ICollection<Cart_Itemes> Cart_Itemes { get; set; }
        public virtual Category Category1 { get; set; }
    }
}
