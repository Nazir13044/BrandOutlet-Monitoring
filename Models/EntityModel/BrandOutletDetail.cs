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
    
    public partial class BrandOutletDetail
    {
        public long Id { get; set; }
        public Nullable<System.Guid> BrandOutletToken { get; set; }
        public Nullable<long> RetailerId { get; set; }
        public Nullable<long> BrandCategoryId { get; set; }
        public string BrandCategoryName { get; set; }
        public Nullable<long> BrandSubCategoryId { get; set; }
        public string BrandSubCategoryName { get; set; }
        public Nullable<long> Quantity { get; set; }
        public Nullable<long> AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
