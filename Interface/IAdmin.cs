using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandOutlet.CustomModel;

namespace BrandOutlet.Interface
{
    interface IAdmin
    {
        bool InsertImage(ImageViewModel model);
        //List<tblImageUploader> DisplayingImage(long id);
    }
}
