using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandOutlet.Models.EntityModel;
using Brand_Monitor;

namespace BrandOutlet.Interface
{
    public interface IBrand
    {

        bool InsertBrandMonitorCategoryInfo(BrandMonitorCategory brandInfo);

        BrandMonitorCategory BrandMonitorCategoryNameExist(BrandMonitorCategory brandInfo);
        List<BrandMonitorCategory> GetNameList();
        bool InsertBrandShopInfo(BrandShop shopInfo);
        bool InsertBrandMonitorSubCategoryInfo(BrandMonitorSubCategory subInfo);
        bool InsertCreateAccountInfo(tblCreateAccount accountInfo);
        tblCreateAccount MobileNumberExist(tblCreateAccount accountInfo);
        bool InsertLoginInfo(BrandLogin logInfo);
        BrandLogin LoginNameExist(BrandLogin logInfo);

        List<BrandShop> GetBrandShopListDatatable();



        bool UpadteBrandShopInfo(BrandShop shopInfo);
        BrandShop EditBrandShopListById(long id);
        List<BrandMonitorCategory> GetBrandMonitorList();
        List<BrandMonitorCategory> EditBrandMonitorListById(long id);
        bool UpadteBrandMonitorCategoryInfo(BrandMonitorCategory brandMonitorInfo);
        List<BrandSubCategoryModel> GetBrandSubCategoryList();
        List<BrandSubCategoryModel> EditBrandSubCategorById(long id);
        bool UpdateBrandSubCategoryInformation(BrandMonitorSubCategory subcatergoryInfo);
    }
}
