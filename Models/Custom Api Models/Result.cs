using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrandApi.Models.Custom_Models
{
    public class Result
    {

        public bool error { get; set; }
        public int issuccess { get; set; }
        public string message { get; set; }
        public int status { get; set; }

        
    }
}