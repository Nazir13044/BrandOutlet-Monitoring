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
    
    public partial class BrandMonitorSubCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Nullable<long> BrandMonitorId { get; set; }
        public Nullable<decimal> Duration { get; set; }
        public string DurationType { get; set; }
        public Nullable<bool> ValidityOver { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> AddedBy { get; set; }
        public Nullable<long> EditedBy { get; set; }
        public Nullable<System.DateTime> EditedDate { get; set; }
        public Nullable<long> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
    }
}