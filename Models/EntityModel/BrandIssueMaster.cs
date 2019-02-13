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
    
    public partial class BrandIssueMaster
    {
        public long Id { get; set; }
        public Nullable<System.Guid> IssueId { get; set; }
        public Nullable<long> CategoryId { get; set; }
        public Nullable<long> SubCategoryId { get; set; }
        public string Description { get; set; }
        public string RetailersPhone { get; set; }
        public string RetailersAddress { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> Solved { get; set; }
        public Nullable<bool> Trash { get; set; }
        public Nullable<bool> Seen { get; set; }
        public Nullable<long> AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<long> SolvedBy { get; set; }
        public Nullable<System.DateTime> SolvedDate { get; set; }
        public Nullable<long> TrashBy { get; set; }
        public Nullable<System.DateTime> TrashDate { get; set; }
        public Nullable<long> ReActiveBy { get; set; }
        public Nullable<System.DateTime> ReActiveDate { get; set; }
    }
}