using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Web;
using BrandOutlet.Interface;
using BrandOutlet.Models;
using BrandOutlet.Models.EntityModel;

namespace BrandOutlet.Repository
{
    public class BrandOutletRepository : IBrandOutlet
    {
        private readonly BrandOutletMonitoringEntities _entities = new BrandOutletMonitoringEntities();
        public List<Retailer> GetRetailers(string term)
        {
            List<Retailer> retailers;

            using (var entity = new RetailerMotivationProgramEntities())
            {

                retailers =
                    entity.Retailers.Where(a => a.RetailerName.ToLower().Contains(term.ToLower()) && a.IsActive == true)
                        .ToList();
            }
            return retailers;
        }

        public List<BrandMonitorCategory> GetBrandCategoryDetails(string term)
        {
            List<BrandMonitorCategory> categories;

            using (var entity = new BrandOutletMonitoringEntities())
            {

                categories =
                    entity.BrandMonitorCategories.Where(a => a.Name.ToLower().Contains(term.ToLower())).ToList();
            }
            return categories;
        }

        public List<BrandMonitorSubCategory> GetBrandSubCategory(long id)
        {
            List<BrandMonitorSubCategory> subCategories;

            using (var entity = new BrandOutletMonitoringEntities())
            {

                subCategories = entity.BrandMonitorSubCategories.Where(a => a.BrandMonitorId == id).ToList();
            }
            return subCategories;
        }
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        public bool InsertNewBrandOutletMasterInfo(List<NewBrandOutletModel> newBrandOutlet, Guid? tokenNumber)
        {
            try
            {
                using (var entity = new BrandOutletMonitoringEntities())
                {


                    var outletMaster = new BrandOutletMaster();
                    outletMaster.OutletToken = tokenNumber;
                    outletMaster.RetailerId = newBrandOutlet[0].RetailerId;
                    outletMaster.RetailerName = newBrandOutlet[0].RetailerName;
                    outletMaster.RetailerAddress = newBrandOutlet[0].RetailerAddress;
                    outletMaster.RetailerPhone = newBrandOutlet[0].RetailerPhone;
                    outletMaster.AddedBy = 1;
                    outletMaster.Active = true;
                    outletMaster.AddedDate = DateTime.Now;
                    entity.BrandOutletMasters.Add(outletMaster);





                    entity.SaveChanges();
                }

                return true;
            }
            catch (Exception exception)
            {
                return false;

            }
        }

        public bool InsertNewBrandOutletMasterDetailsInfo(List<NewBrandOutletModel> newBrandOutlet, Guid? tokenNumber)
        {
            try
            {
                using (var entity = new BrandOutletMonitoringEntities())
                {
                    foreach (var newBrandOutletModel in newBrandOutlet)
                    {
                        var outletMaster = new BrandOutletDetail();
                        outletMaster.BrandOutletToken = tokenNumber;
                        outletMaster.RetailerId = newBrandOutletModel.RetailerId;
                        outletMaster.BrandCategoryId = newBrandOutletModel.BrandCategoryId;
                        outletMaster.BrandCategoryName = newBrandOutletModel.BrandCategoryName;
                        outletMaster.BrandSubCategoryId = newBrandOutletModel.BrandSubCategoryId;
                        outletMaster.BrandSubCategoryName = newBrandOutletModel.BrandSubCategoryName;
                        outletMaster.Quantity = newBrandOutletModel.Quantity;
                        outletMaster.AddedBy = 1;
                        outletMaster.AddedDate = DateTime.Now;
                        outletMaster.UpdatedBy = 1;
                        outletMaster.UpdatedDate = DateTime.Now;

                        entity.BrandOutletDetails.Add(outletMaster);
                    }

                    entity.SaveChanges();
                }

                return true;
            }
            catch (Exception exception)
            {
                return false;

            }
        }

    

        public bool InsertNewBrandOutletlogInfo(List<NewBrandOutletModel> newBrandOutlet, Guid? tokenNumber)
        {
            try
            {
                using (var entity = new BrandOutletMonitoringEntities())
                {
                    foreach (var newBrandOutletModel in newBrandOutlet)
                    {
                        var outletMaster = new BrandOutletLog();
                        outletMaster.OutletTokenId = tokenNumber;
                        outletMaster.RetailerId = newBrandOutletModel.RetailerId;
                        outletMaster.CategoryId = newBrandOutletModel.BrandCategoryId;
                        outletMaster.CategoryName = newBrandOutletModel.BrandCategoryName;
                        outletMaster.SubCategoryId = newBrandOutletModel.BrandSubCategoryId;
                        outletMaster.SubCategoryName = newBrandOutletModel.BrandSubCategoryName;
                        outletMaster.Quantity = newBrandOutletModel.Quantity;
                        outletMaster.Type = newBrandOutletModel.Type;
                        outletMaster.AddedBy = 1;
                        outletMaster.AddedDate = DateTime.Now;


                        entity.BrandOutletLogs.Add(outletMaster);
                    }

                    entity.SaveChanges();
                }

                return true;
            }
            catch (Exception exception)
            {
                return false;

            }
        }

        public List<BrandOutletMaster> GetOutetRetailers(string term)
        {
            List<BrandOutletMaster> retailers;

            using (var entity = new BrandOutletMonitoringEntities())
            {

                retailers =
                    entity.BrandOutletMasters.Where(
                        a => a.RetailerName.ToLower().Contains(term.ToLower()) && a.Active == true).ToList();
            }
            return retailers;
        }

        public List<BrandOutletDetail> BrandOutletDetails(Guid? token)
        {
            List<BrandOutletDetail> details;

            using (var entity = new BrandOutletMonitoringEntities())
            {

                details = entity.BrandOutletDetails.Where(a => a.BrandOutletToken == token).ToList();
            }
            return details;
        }

        public bool UpdateBrandOutletMasterDetailsInfo(List<NewBrandOutletModel> reBrandItems)
        {

            try
            {
                using (var entity = new BrandOutletMonitoringEntities())
                {



                    foreach (var items in reBrandItems)
                    {
                        var shopInfoes = entity.BrandOutletDetails.FirstOrDefault(x => x.BrandOutletToken == items.Token
                            && x.BrandCategoryId == items.BrandCategoryId && x.BrandSubCategoryId == items.BrandSubCategoryId);
                        if (shopInfoes != null)
                        {
                            if (items.Quantity != 0)
                                shopInfoes.Quantity = items.Quantity;


                            shopInfoes.UpdatedBy = 1;
                            shopInfoes.UpdatedDate = DateTime.Now;


                            entity.Entry(shopInfoes).State = EntityState.Modified;

                        }


                        entity.SaveChanges();

                    }

                }
            }
            catch (Exception)
            {

                return false;
            }
           

            return true;
        }

        public List<BrandOutletMaster> GetBrandOutletMasterDatatable()
        {
            List<BrandOutletMaster> list = null;
            try
            {
                list = _entities.BrandOutletMasters.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }
    }
}

