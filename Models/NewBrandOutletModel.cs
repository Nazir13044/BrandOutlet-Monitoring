using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrandOutlet.Models
{
    public class NewBrandOutletModel
    {

        public long? RetailerId { get; set; }

        public Guid? Token { get; set; }
        public string RetailerName { get; set; }
        public string RetailerPhone { get; set; }
        public string RetailerAddress { get; set; }
        public long? BrandCategoryId { get; set; }
        public string BrandCategoryName { get; set; }
        public long? BrandSubCategoryId { get; set; }
        public string BrandSubCategoryName { get; set; }
        public long? Quantity { get; set; }

        public string Type { get; set; }


    }
}