using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BrandOutlet.Manager;
using BrandOutlet.Models.EntityModel;
using Microsoft.Ajax.Utilities;
using Brand_Monitor;
using WCMS_MAIN.HelperClass;

namespace BrandOutlet.Controllers
{
    public class BrandController : Controller
    {
        
        
        #region Fields

        private readonly BrandIssueManager _brandIssueManager;//= new BrandIssueManager();
        private readonly AdminManager _adminManager;
        private readonly BrandingIssueSolvedManager _brandingIssueSolvedManager;
        private readonly BrandingTeamManager _brandingTeamManager;
        private readonly BrandManager _brandManager;
        private readonly BrandOutletManager _brandOutletManager;
        readonly Dictionary<int, SessionData> _sessiondictionary = SessionData.GetSessionValues();
        
        #endregion

        #region Ctor
        public BrandController()
        {
            _brandIssueManager = new BrandIssueManager();
            _adminManager = new AdminManager();
            _brandingIssueSolvedManager = new BrandingIssueSolvedManager();
            _brandingTeamManager = new BrandingTeamManager();
            _brandManager = new BrandManager();
            _brandOutletManager = new BrandOutletManager();

        }


        #endregion






        public ActionResult Home()
        {
            return View();
        }
        public ActionResult BrandMonitoringCategory()
        {
            return View();
        }

        public ActionResult BrandSubCategory()
        {
            return View();
        }

        public ActionResult BrandShop()
        {
            return View();
        }

        public ActionResult CreateAccount()
        {
            return View();
        }

        public ActionResult login()
        {
            return View();
        }

       
        public JsonResult InsertLoginInfo(BrandLogin logInfo)
        {
            var result = new Result();
            var userId = (long)_sessiondictionary[1].Id;
            var userName = _sessiondictionary[2].Name;

            try
            {
                var existUser = _brandManager.LoginNameExist(new BrandLogin() { Name = logInfo.Name });

                if (existUser == null)
                {
                    logInfo.AddedBy = userId;
                    logInfo.AddedDate = DateTime.Now;
                    result = _brandManager.InsertLoginInfo(logInfo);
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Current Name Already Exists";
                }
            }
            catch (Exception ex)
            {




            }
            return Json(result, JsonRequestBehavior.AllowGet);
            
            return Json(result);
        }
        public JsonResult InsertBrandMonitorCategoryInfo(BrandMonitorCategory brandInfo)
        {
            var userId = (long)_sessiondictionary[1].Id;
            var userName = (long)_sessiondictionary[2].Id;
           
            var result = new Result();

            try
            {
                var categoryNameExist = _brandManager.BrandMonitorCategoryNameExist(new BrandMonitorCategory(){Name = brandInfo.Name});

                if (categoryNameExist == null)
                {
                    brandInfo.AddedBy = userId;
                    brandInfo.AddedDate = DateTime.Now;
                    brandInfo.Active = true;
                    result = _brandManager.InsertBrandMonitorCategoryInfo(brandInfo);
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Current Name Already Exists";
                }
            }
            catch (Exception ex)
            {

            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public JsonResult InsertBrandShopInfo(BrandShop shopInfo)
        {

            var userId = (long)_sessiondictionary[1].Id;
            var userName = (long)_sessiondictionary[2].Id;
            Result result;
            try
            {
                
                shopInfo.AddedBy = userId;
                shopInfo.AddedDate = DateTime.Now;
                shopInfo.Active = true;
                result = _brandManager.InsertBrandShopInfo(shopInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(result);
        }

        public JsonResult InsertCreateAccountInfo(tblCreateAccount accountInfo)
        {
            var userId = (long)_sessiondictionary[1].Id;
            var userName = (long)_sessiondictionary[2].Id;
            var result = new Result();
            try
            {
                var existUser = _brandManager.MobileNumberExist(new tblCreateAccount() { Mobile = accountInfo.Mobile });

                if (existUser == null)
                {
                    
                    accountInfo.AddedDate = DateTime.Now;
                    result = _brandManager.InsertCreateAccountInfo(accountInfo);
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Current Mobile Number Already Exists";
                }
            }
            catch (Exception ex)
            {

            }
            return Json(result, JsonRequestBehavior.AllowGet);        
        }
        public JsonResult InsertBrandMonitorSubCategoryInfo(BrandMonitorSubCategory subInfo)
        {
            var userId = (long)_sessiondictionary[1].Id;
           // var userName = (long)_sessiondictionary[2].Id;
                
            var result = new Result();
            try
            {
                subInfo.AddedBy = userId;
                subInfo.AddedDate = DateTime.Now;
                subInfo.Active = true;
                result = _brandManager.InsertBrandMonitorSubCategoryInfo(subInfo);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
            return Json(result);
        }
        public JsonResult GetNameList()
        {


            var list = new List<BrandMonitorCategory>();
            try
            {
                list = _brandManager.GetNameList().ToList();

            }
            catch (Exception ex)
            {

            }
            //var objstate = list.Select(x => new { value = x.Name, id = x.Id, }).ToList();
            return Json(list.ToArray(), JsonRequestBehavior.AllowGet);
            //return Json(list, JsonRequestBehavior.AllowGet);

          
        }

        public JsonResult GetBrandShopListDatatable()
        {


            var list = new List<BrandShop>();
            try
            {
                list = _brandManager.GetBrandShopListDatatable();

            }
            catch (Exception ex)
            {

            }

            return Json(new { data = list }, JsonRequestBehavior.AllowGet);


        }

        public JsonResult GetBrandMonitorList()
        {
            var list = new List<BrandMonitorCategory>();
            var newlist = new List<BrandMonitorCategory>();
            try
            {
                list = _brandManager.GetBrandMonitorList();
               
                foreach (var items in list)
                {

                    var brandMonitor = new BrandMonitorCategory();
                    brandMonitor.Id = items.Id;
                    brandMonitor.Name = items.Name;
                    brandMonitor.Type = items.Type;
                    brandMonitor.Remarks = items.Remarks;

                    newlist.Add(brandMonitor);
                }
            }
            catch (Exception ex)
            {

            }

            return Json(new { data = newlist }, JsonRequestBehavior.AllowGet);


        }
        public JsonResult GetBrandSubCategoryList()
        {

            var list = new List<BrandSubCategoryModel>();
            try
            {
                list = _brandManager.GetBrandSubCategoryList();

            }
            catch (Exception ex)
            {

            }

            return Json(new { data = list }, JsonRequestBehavior.AllowGet);


        }
        
        public JsonResult UpadteBrandShopInfo(BrandShop shopInfo, string type)
        {
            var result = new Result();
            if (type == "E")
            {
                //shopInfo.EditedBy = Id;
                shopInfo.EditedDate = DateTime.Now;
                result = _brandManager.UpadteBrandShopInfo(shopInfo);

            }
            else
            {
                shopInfo.DeletedDate = DateTime.Now;

                result = _brandManager.UpadteBrandShopInfo(shopInfo);
            }
            return Json(result);
        }

        public JsonResult UpadteBrandMonitorCategoryInfo(BrandMonitorCategory brandMonitorInfo, string type)
        {
            var result = new Result();
            if (type == "E")
            {
                //brandMonitorInfo.EditedBy = Id;
                brandMonitorInfo.EditedDate = DateTime.Now;
                result = _brandManager.UpadteBrandMonitorCategoryInfo(brandMonitorInfo);

            }
            else
            {
                brandMonitorInfo.DeletedDate = DateTime.Now;

                result = _brandManager.UpadteBrandMonitorCategoryInfo(brandMonitorInfo);
            }
            return Json(result);
        }


        public JsonResult UpdateBrandSubCategoryInformation(BrandMonitorSubCategory subcatergoryInfo, string type)
        {
            var result = new Result();
            if (type == "E")
            {
                //brandMonitorInfo.EditedBy = Id;
                subcatergoryInfo.EditedDate = DateTime.Now;
                result = _brandManager.UpdateBrandSubCategoryInformation(subcatergoryInfo);

            }
            else
            {
                subcatergoryInfo.DeletedDate = DateTime.Now;

                result = _brandManager.UpdateBrandSubCategoryInformation(subcatergoryInfo);
            }
            return Json(result);
        }
        public JsonResult EditBrandShopListById(long id)
        {

            var list = new BrandShop();
            try
            {
                list = _brandManager.EditBrandShopListById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditBrandSubCategorById(long id)
        {

            var list = new List<BrandSubCategoryModel>();
            try
            {
                list = _brandManager.EditBrandSubCategorById(id).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        
        public JsonResult EditBrandMonitorListById(long id)
        {
            var list = new List<BrandMonitorCategory>();
            var newlist = new List<BrandMonitorCategory>();
            try
            {    
                list = _brandManager.EditBrandMonitorListById(id).ToList();
                foreach (var items in list)
                {
                    var brandMonitor = new BrandMonitorCategory();
                    brandMonitor.Id = items.Id;
                    brandMonitor.Type = items.Type;
                    brandMonitor.Name = items.Name;
                    brandMonitor.Remarks = items.Remarks;
                    newlist.Add(brandMonitor);
                }
               
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(newlist.ToArray(), JsonRequestBehavior.AllowGet);
        }

        
    }
}