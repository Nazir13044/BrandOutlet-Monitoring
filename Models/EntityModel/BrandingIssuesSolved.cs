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
    
    public partial class BrandingIssuesSolved
    {
        public long Id { get; set; }
        public Nullable<System.Guid> IssueId { get; set; }
        public string Remarks { get; set; }
        public string Solutions { get; set; }
        public Nullable<long> AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> UpdatededBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
