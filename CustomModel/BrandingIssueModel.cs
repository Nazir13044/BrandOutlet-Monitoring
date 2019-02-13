using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrandOutlet.CustomModel
{
    public class BrandingIssueModel
    {
            public long Id { get; set; }

            public Guid? IssueId { get; set; }
            public long? BrandId { get; set; }
            public long? SubCategoryid { get; set; }
            public string Description { get; set; }
            public string IssueFile { get; set; }
            public string BrandCategory { get; set; }
            public string BrandSubCategory { get; set; }
            public string RetailerPhone { get; set; }
            public string RetailerAddress { get; set; }


            public string FileExtension { get; set; }
            public string Remarks { get; set; }
     
            public long? AddedBy { get; set; }
            public DateTime? AddedDate { get; set; }
             public string Solutions { get; set; }
    }
}