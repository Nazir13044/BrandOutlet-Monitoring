using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandOutlet.Models.EntityModel;

namespace BrandOutlet.Interface
{
    interface IBrandOutlet
    {
        List<Models.EntityModel.Retailer> GetRetailers(string term);

        List<Models.EntityModel.BrandMonitorCategory> GetBrandCategoryDetails(string term);

        List<Models.EntityModel.BrandMonitorSubCategory> GetBrandSubCategory(long id);

        bool InsertNewBrandOutletMasterInfo(List<Models.NewBrandOutletModel> newBrandOutlet, Guid? tokenNumber);

        bool InsertNewBrandOutletMasterDetailsInfo(List<Models.NewBrandOutletModel> newBrandOutlet, Guid? tokenNumber);

        bool InsertNewBrandOutletlogInfo(List<Models.NewBrandOutletModel> newBrandOutlet, Guid? tokenNumber);

        List<Models.EntityModel.BrandOutletMaster> GetOutetRetailers(string term);

        List<Models.EntityModel.BrandOutletDetail> BrandOutletDetails(Guid? token);

        bool UpdateBrandOutletMasterDetailsInfo(List<Models.NewBrandOutletModel> reBrandItems);
        List<BrandOutletMaster> GetBrandOutletMasterDatatable();
    }
}
