using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrandOutlet
{
    public class BrandSubCategoryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long? BrandMonitorId { get; set; }
        public string BrandingCategoryName { get; set; }
        public decimal? Duration { get; set; }
        public string DurationType { get; set; }
        public bool? ValidityOver { get; set; }
        public bool? Active { get; set; }
        public DateTime? AddedDate { get; set; }

      
    }
}