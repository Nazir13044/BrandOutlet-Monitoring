using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using BrandOutlet.Interface;
using BrandOutlet.Models;
using BrandOutlet.Models.EntityModel;
using BrandOutlet.Repository;
using Brand_Monitor;
using BR_BLL;

namespace BrandOutlet.Manager
{
    public class BrandOutletManager
    {
        IBrandOutlet _iBrandOutlet = new BrandOutletRepository();



       

        public List<Retailer> GetRetailers(string term)
        {
            var retailers = new List<Retailer>();
            try
            {
                retailers = _iBrandOutlet.GetRetailers(term);
            }
            catch (Exception ex)
            {
               
            }

            return retailers;
        }

        public List<BrandMonitorCategory> GetBrandCategoryDetails(string term)
        {
            var brands = new List<BrandMonitorCategory>();
            try
            {
                brands = _iBrandOutlet.GetBrandCategoryDetails(term);
            }
            catch (Exception ex)
            {

            }

            return brands;
        }

        public List<BrandMonitorSubCategory> GetBrandSubCategory(long id)
        {
            var brandsub = new List<BrandMonitorSubCategory>();
            try
            {
                brandsub = _iBrandOutlet.GetBrandSubCategory(id);
            }
            catch (Exception ex)
            {

            }

            return brandsub;
        }

        public Result InsertNewBrandOutletMasterInfo(List<NewBrandOutletModel> newBrandOutlet, Guid? tokenNumber)
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required,ApplicationState.TransactionOptions))
                {

                    var result = new Result { IsSuccess = _iBrandOutlet.InsertNewBrandOutletMasterInfo(newBrandOutlet, tokenNumber) };


                    if (result.IsSuccess)
                    {

                        result = new Result { IsSuccess = _iBrandOutlet.InsertNewBrandOutletMasterDetailsInfo(newBrandOutlet, tokenNumber) };
                    }

                   // InsertNewBrandOutletlogInfo(newBrandOutlet, tokenNumber);
                    if (result.IsSuccess)
                    {
                        result = new Result { IsSuccess = _iBrandOutlet.InsertNewBrandOutletlogInfo(newBrandOutlet, tokenNumber) };

                    }


                    if (result.IsSuccess)
                    {
                        transaction.Complete();
                        return result;
                    }

                    else
                    {
                         result.Message="Data Not Saved";
                        return result;
                    }

                }

            }



            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal Result InsertNewBrandOutletMasterDetailsInfo(List<NewBrandOutletModel> newBrandOutlet, Guid tokenNumber)
        {
            try
            {
                var result = new Result { IsSuccess = _iBrandOutlet.InsertNewBrandOutletMasterDetailsInfo(newBrandOutlet, tokenNumber) };
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal Result InsertNewBrandOutletlogInfo(List<NewBrandOutletModel> newBrandOutlet, Guid tokenNumber)
        {
            try
            {
                var result = new Result { IsSuccess = _iBrandOutlet.InsertNewBrandOutletlogInfo(newBrandOutlet, tokenNumber) };
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BrandOutletMaster> GetOutetRetailers(string term)
        {
            var retailers = new List<BrandOutletMaster>();
            try
            {
                retailers = _iBrandOutlet.GetOutetRetailers(term);
            }
            catch (Exception ex)
            {

            }

            return retailers;
        }

        public List<BrandOutletDetail> BrandOutletDetails(Guid? token)
        {
            var brandoutlet = new List<BrandOutletDetail>();
            try
            {
                brandoutlet = _iBrandOutlet.BrandOutletDetails(token);
            }
            catch (Exception ex)
            {

            }

            return brandoutlet;
        }

        public Result UpdateBrandOutletMasterDetailsInfo(List<NewBrandOutletModel> reBrandItems)
        {
            try
            {
                var result = new Result { IsSuccess = _iBrandOutlet.UpdateBrandOutletMasterDetailsInfo(reBrandItems) };
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BrandOutletMaster> GetBrandOutletMasterDatatable()
        {
            try
            {
                return _iBrandOutlet.GetBrandOutletMasterDatatable();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}