using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrandApi.Models.Custom_Models
{
    public class BrandingIssueModel
    {

        public long Id { get; set; }
        public long? BrandId { get; set; }
        public long? SubCategoryid { get; set; }
        public string Description { get; set; }
        public string IssueFile { get; set; }

        public string FileExtension { get; set; }



    }
}