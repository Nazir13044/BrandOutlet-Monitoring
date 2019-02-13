using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrandOutlet.CustomModel
{
    public class ImageViewModel
    {

        public int ImageId { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageByte { get; set; }
        public string ImagePath { get; set; }
        public HttpPostedFileWrapper ImageFile { get; set; }
    }
}