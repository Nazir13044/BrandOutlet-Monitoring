using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrandApi.Models.Custom_Models
{
    public class BrandCategory
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string remarks { get; set; }
        public string addedby { get; set; }
        public string bpdealername { get; set; }
        public string bpdealercode { get; set; }
    }
}