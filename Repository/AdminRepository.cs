using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using BrandOutlet.CustomModel;
using BrandOutlet.Interface;
using BrandOutlet.Models.EntityModel;

namespace BrandOutlet.Repository
{
    public class AdminRepository : IAdmin
    {
        private readonly BrandOutletMonitoringEntities _entities = new BrandOutletMonitoringEntities();

        public bool InsertImage(ImageViewModel model)
        {


            var file = model.ImageFile;
            byte[] imagebyte = null;
            if (file != null)
            {
                BinaryReader reader = new BinaryReader(file.InputStream);
                imagebyte = reader.ReadBytes(file.ContentLength);
                tblImageUploader img = new tblImageUploader();
                img.ImageTitle = file.FileName;
                img.ImageByte = imagebyte;

                _entities.tblImageUploaders.Add(img);
                _entities.SaveChanges();


                return true;
            }
            return true;
        }

       
    }
}