//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrandOutlet.Models.EntityModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class BrandShop
    {
        public long Id { get; set; }
        public string ShopName { get; set; }
        public string ShopCategory { get; set; }
        public string Address { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string OwnerName { get; set; }
        public string Phone { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<long> AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> EditedBy { get; set; }
        public Nullable<System.DateTime> EditedDate { get; set; }
        public Nullable<long> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
    }
}