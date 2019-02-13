using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using BrandOutlet.Interface;
using BrandOutlet.Models.EntityModel;
using Brand_Monitor;

namespace BrandOutlet.Repository
{
    public class BrandRepository : IBrand
    {

        private readonly BrandOutletMonitoringEntities _entities;

        public BrandRepository()
        {
            _entities = new BrandOutletMonitoringEntities();
        }





        //private readonly BrandOutletMonitoringEntities _entities = new BrandOutletMonitoringEntities();
        public bool InsertBrandMonitorCategoryInfo(BrandMonitorCategory brandInfo)
        {
            try
            {

                _entities.BrandMonitorCategories.Add(brandInfo);
                _entities.SaveChanges();


                return true;
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }
        public bool InsertBrandShopInfo(BrandShop shopInfo)
        {
            try
            {

                _entities.BrandShops.Add(shopInfo);
                _entities.SaveChanges();


                return true;
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public bool InsertCreateAccountInfo(tblCreateAccount accountInfo)
        {
            try
            {

                _entities.tblCreateAccounts.Add(accountInfo);
                _entities.SaveChanges();


                return true;
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }
        public bool InsertBrandMonitorSubCategoryInfo(BrandMonitorSubCategory subInfo)
        {
            try
            {

                _entities.BrandMonitorSubCategories.Add(subInfo);
                _entities.SaveChanges();


                return true;
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }


       
        //public BrandMonitorCategory BrandMonitorCategory(BrandMonitorCategory brandInfo)
        //{
        //    throw new NotImplementedException();
        //}
        public BrandMonitorCategory BrandMonitorCategoryNameExist(BrandMonitorCategory brandInfo)
        {

          BrandMonitorCategory brand;

            try
            {
                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(1).AddTicks(-1);

               brand = _entities.BrandMonitorCategories.FirstOrDefault(a => a.Name == brandInfo.Name);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return brand;
        }

        public BrandLogin LoginNameExist(BrandLogin logInfo)
        {

            BrandLogin log;

            try
            {
                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(1).AddTicks(-1);

                log = _entities.BrandLogins.FirstOrDefault(a => a.Name == logInfo.Name);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return log;
        }

        public List<BrandShop> GetBrandShopListDatatable()
        {
            List<BrandShop> list;
            try
            {
                list = _entities.BrandShops.Where(x => x.Active == true).ToList();                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }
        public List<BrandMonitorCategory> GetBrandMonitorList()
        {
            List<BrandMonitorCategory> list;
            try
            {
                list = _entities.BrandMonitorCategories.Where(x => x.Active == true).ToList();
                //list = _entities.BrandShops.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }
        public List<BrandSubCategoryModel> GetBrandSubCategoryList()
        {
            List<BrandSubCategoryModel> list;
            try
            {
              
                list = (from brandSubCategory in _entities.BrandMonitorSubCategories
                        join brandCategory in _entities.BrandMonitorCategories on
                        brandSubCategory.BrandMonitorId equals brandCategory.Id
                        where brandSubCategory.Active==true
                           
                     
                        select new BrandSubCategoryModel
                {
                    Id=brandSubCategory.Id,
                    Name=brandSubCategory.Name,
                    Type=brandSubCategory.Type,
                    //BrandMonitorId = brandSubCategory.BrandMonitorId,
                    Duration = brandSubCategory.Duration,
                    DurationType = brandSubCategory.DurationType,
                    BrandingCategoryName=brandCategory.Name
                }).ToList();
                


                //list =_entities.BrandMonitorSubCategories.Where(x => x.Active == true).ToList();
                //list = _entities.BrandShops.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public object Id { get; set; }


        public tblCreateAccount MobileNumberExist(tblCreateAccount accountInfo)
        {

          tblCreateAccount account;

            try
            {
                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(1).AddTicks(-1);

                account = _entities.tblCreateAccounts.FirstOrDefault(a => a.Mobile == accountInfo.Mobile);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return account;
        }
        public List<BrandMonitorCategory> GetNameList()
        {
            List<BrandMonitorCategory> list;
            try
            {
                list = _entities.BrandMonitorCategories.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public bool InsertLoginInfo(BrandLogin logInfo)
        {
            try
            {

                _entities.BrandLogins.Add(logInfo);
                _entities.SaveChanges();


                return true;
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

       

        public BrandShop EditBrandShopListById(long id)
        {
            BrandShop list;
            try
            {
                list = _entities.BrandShops.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public  List<BrandSubCategoryModel> EditBrandSubCategorById(long id)
        {
            List<BrandMonitorSubCategory> list;
            List<BrandSubCategoryModel> modellisT;
            try
            {
                list = _entities.BrandMonitorSubCategories.Where(x => x.Id == id).ToList();
                modellisT = (from newList in list

                        select new BrandSubCategoryModel
                        {
                            Id = newList.Id,
                            Name = newList.Name,
                            Type = newList.Type,
                            Duration = newList.Duration,
                            DurationType = newList.DurationType,
                            BrandingCategoryName = newList.Name,
                            BrandMonitorId = newList.BrandMonitorId
                        }).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return modellisT;
        }
        
        public List<BrandMonitorCategory> EditBrandMonitorListById(long id)
        {
            List<BrandMonitorCategory> list;
            try
            {
                list = _entities.BrandMonitorCategories.Where(x => x.Id == id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }



        public bool UpadteBrandShopInfo(BrandShop shopInfo)
        {
            BrandShop shopInfoes = _entities.BrandShops.FirstOrDefault(x => x.Id == shopInfo.Id);
            if (shopInfo != null)
            {
                if (shopInfo.ShopName != null)
                    if (shopInfoes != null) shopInfoes.ShopName = shopInfo.ShopName;
                if (shopInfo.ShopCategory != null)
                    if (shopInfoes != null) shopInfoes.ShopCategory = shopInfo.ShopCategory;
                if (shopInfo.Address != null)
                    if (shopInfoes != null) shopInfoes.Address = shopInfo.Address;
                if (shopInfo.Code != null)
                    if (shopInfoes != null) shopInfoes.Code = shopInfo.Code;
                if (shopInfo.OwnerName != null)
                    if (shopInfoes != null) shopInfoes.OwnerName = shopInfo.OwnerName;
                if (shopInfo.Phone != null)
                    if (shopInfoes != null) shopInfoes.Phone = shopInfo.Phone;
                if (shopInfo.Active != null)
                    if (shopInfoes != null) shopInfoes.Active = shopInfo.Active;
                if (shopInfo.EditedDate != null)
                    if (shopInfoes != null) shopInfoes.EditedDate = shopInfo.EditedDate;
                if (shopInfo.DeletedDate != null)
                    if (shopInfoes != null) shopInfoes.DeletedDate = shopInfo.DeletedDate;
                _entities.Entry(shopInfoes).State = EntityState.Modified;
                _entities.SaveChanges();

            }

            else
            {
                return false;
            }

                return true;
         }




        public bool UpadteBrandMonitorCategoryInfo(BrandMonitorCategory brandMonitorInfo)
        {
            BrandMonitorCategory brandMonitorInfoes = _entities.BrandMonitorCategories.FirstOrDefault(x => x.Id == brandMonitorInfo.Id);
            if (brandMonitorInfo != null)
            {
                if (brandMonitorInfo.Name != null)
                    if (brandMonitorInfoes != null) brandMonitorInfoes.Name = brandMonitorInfo.Name;
                if (brandMonitorInfo.Type != null)
                    if (brandMonitorInfoes != null) brandMonitorInfoes.Type = brandMonitorInfo.Type;
                if (brandMonitorInfo.Remarks != null)
                    if (brandMonitorInfoes != null) brandMonitorInfoes.Remarks = brandMonitorInfo.Remarks;

                if (brandMonitorInfo.Active != null)
                    if (brandMonitorInfoes != null) brandMonitorInfoes.Active = brandMonitorInfo.Active;
                if (brandMonitorInfo.EditedDate != null)
                    if (brandMonitorInfoes != null) brandMonitorInfoes.EditedDate = brandMonitorInfo.EditedDate;
                if (brandMonitorInfo.DeletedDate != null)
                    if (brandMonitorInfoes != null) brandMonitorInfoes.DeletedDate = brandMonitorInfo.DeletedDate;
                _entities.Entry(brandMonitorInfoes).State = EntityState.Modified;
                _entities.SaveChanges();

            }

            else
            {
                return false;
            }

                return true;
         }


        public bool UpdateBrandSubCategoryInformation(BrandMonitorSubCategory subcatergoryInfo)
        {
            BrandMonitorSubCategory brandMonitorsubcategoryInfoes = _entities.BrandMonitorSubCategories.FirstOrDefault(x => x.Id == subcatergoryInfo.Id);
            if (subcatergoryInfo != null)
            {
                if (subcatergoryInfo.Name != null)
                    if (brandMonitorsubcategoryInfoes != null) brandMonitorsubcategoryInfoes.Name = subcatergoryInfo.Name;
                if (subcatergoryInfo.Type != null)
                    if (brandMonitorsubcategoryInfoes != null) brandMonitorsubcategoryInfoes.Type = subcatergoryInfo.Type;
                if (subcatergoryInfo.Duration != null)
                    if (brandMonitorsubcategoryInfoes != null) brandMonitorsubcategoryInfoes.Duration = subcatergoryInfo.Duration;
                if (subcatergoryInfo.DurationType != null)          
                    if (brandMonitorsubcategoryInfoes != null) brandMonitorsubcategoryInfoes.DurationType = subcatergoryInfo.DurationType;
                
                if (subcatergoryInfo.Active != null)
                    if (brandMonitorsubcategoryInfoes != null) brandMonitorsubcategoryInfoes.Active = subcatergoryInfo.Active;
                if (subcatergoryInfo.EditedDate != null)
                    if (brandMonitorsubcategoryInfoes != null) brandMonitorsubcategoryInfoes.EditedDate = subcatergoryInfo.EditedDate;

                if (subcatergoryInfo.DeletedDate != null)
                    if (brandMonitorsubcategoryInfoes != null) brandMonitorsubcategoryInfoes.DeletedDate = subcatergoryInfo.DeletedDate;

                _entities.Entry(brandMonitorsubcategoryInfoes).State = EntityState.Modified;
                _entities.SaveChanges();

            }

            else
            {
                return false;
            }

                return true;
         } 
    }
    }

  
        

       
