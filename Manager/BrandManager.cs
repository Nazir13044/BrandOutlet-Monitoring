using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using BrandOutlet.Interface;
using BrandOutlet.Models.EntityModel;
using BrandOutlet.Repository;
using Brand_Monitor;
using TransactionScope = System.Activities.Statements.TransactionScope;

namespace BrandOutlet.Manager
{

   
    public class BrandManager
    {
        private readonly IBrand _ibrand;

        public BrandManager()
        {
          _ibrand  = new BrandRepository();
        }
        public Result InsertBrandMonitorCategoryInfo(BrandMonitorCategory brandInfo)
        {
            
            var result = new Result();
            try
            {
                result.IsSuccess = _ibrand.InsertBrandMonitorCategoryInfo(brandInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public Result InsertBrandShopInfo(BrandShop shopInfo)
        {
            
            var result = new Result();
            try
            {
                result.IsSuccess = _ibrand.InsertBrandShopInfo(shopInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public Result InsertCreateAccountInfo(tblCreateAccount accountInfo)
        {
            
            var result = new Result();
            try
            {
                result.IsSuccess = _ibrand.InsertCreateAccountInfo(accountInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public Result InsertBrandMonitorSubCategoryInfo(BrandMonitorSubCategory subInfo)
        {
            
            var result = new Result();
            try
            {
                result.IsSuccess = _ibrand.InsertBrandMonitorSubCategoryInfo(subInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public Result InsertLoginInfo(BrandLogin logInfo)
        {
            
            var result = new Result();
            try
            {
                result.IsSuccess = _ibrand.InsertLoginInfo(logInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public BrandMonitorCategory BrandMonitorCategoryNameExist(BrandMonitorCategory brandInfo)
        {
            try
            {

                return _ibrand.BrandMonitorCategoryNameExist(brandInfo);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public BrandLogin LoginNameExist(BrandLogin logInfo)
        {
            try
            {

                return _ibrand.LoginNameExist(logInfo);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public tblCreateAccount MobileNumberExist(tblCreateAccount accountInfo)
        {
            try
            {

                return _ibrand.MobileNumberExist(accountInfo);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<BrandMonitorCategory> GetNameList()
        {
            try
            {
                return _ibrand.GetNameList();
            }
            catch (Exception ex) { throw ex; }
        }
        public List<BrandShop> GetBrandShopListDatatable()
        {
            try
            {
                return _ibrand.GetBrandShopListDatatable();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<BrandMonitorCategory> GetBrandMonitorList()
        {
            try
            {
                IBrand ibrand = new BrandRepository();
                return ibrand.GetBrandMonitorList();
            }
            catch (Exception ex) { throw ex; }
        }
        public List<BrandSubCategoryModel> GetBrandSubCategoryList()
        {
            try
            {
                IBrand ibrand = new BrandRepository();
                return ibrand.GetBrandSubCategoryList();
            }
            catch (Exception ex) { throw ex; }
        }
        
        public BrandShop EditBrandShopListById(long id)
        {
            //var list = new List<BrandShop>();
            try
            {
                IBrand ibrand = new BrandRepository();
                return ibrand.EditBrandShopListById(id);
            }
            catch (Exception ex) { throw ex; }

           
        }

        public List<BrandSubCategoryModel> EditBrandSubCategorById(long id)
        {
            //var list = new List<BrandMonitorSubCategory>();
            try
            {
                IBrand ibrand = new BrandRepository();
                return ibrand.EditBrandSubCategorById(id);
            }
            catch (Exception ex) { throw ex; }

           
        }

        
        public List<BrandMonitorCategory> EditBrandMonitorListById(long id)
        {
            var list = new List<BrandMonitorCategory>();
            try
            {
                IBrand ibrand = new BrandRepository();
                return ibrand.EditBrandMonitorListById(id);
            }
            catch (Exception ex) { throw ex; }

           
        }

        public Result UpadteBrandShopInfo(BrandShop shopInfo)
        {
           
            var result = new Result();
            try
            {
                result.IsSuccess = _ibrand.UpadteBrandShopInfo(shopInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }

        public Result UpadteBrandMonitorCategoryInfo(BrandMonitorCategory brandMonitorInfo)
        {
           
            var result = new Result();
            try
            {
                result.IsSuccess = _ibrand.UpadteBrandMonitorCategoryInfo(brandMonitorInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }

        public Result UpdateBrandSubCategoryInformation(BrandMonitorSubCategory subcatergoryInfo)
        {

            var result = new Result();
            try
            {
                result.IsSuccess = _ibrand.UpdateBrandSubCategoryInformation(subcatergoryInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }
        
       
    }

   
}