using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandOutlet.Manager;
using BrandOutlet.Models;
using BrandOutlet.Models.EntityModel;
using Brand_Monitor;

namespace BrandOutlet.Controllers
{
    public class BrandOutletController : Controller
    {

       

        #region Fields

        private readonly BrandIssueManager _brandIssueManager;//= new BrandIssueManager();
        private readonly AdminManager _adminManager;
        private readonly BrandingIssueSolvedManager _brandingIssueSolvedManager;
        private readonly BrandingTeamManager _brandingTeamManager;
        private readonly BrandManager _brandManager;
        private readonly BrandOutletManager _brandOutletManager;
        
        #endregion

        #region Ctor
        public BrandOutletController()
        {
            _brandIssueManager = new BrandIssueManager();
            _adminManager = new AdminManager();
            _brandingIssueSolvedManager = new BrandingIssueSolvedManager();
            _brandingTeamManager = new BrandingTeamManager();
            _brandManager = new BrandManager();
            _brandOutletManager = new BrandOutletManager();

        }


        #endregion




        public ActionResult NewOutlet()
        {
            return View();
        }
        public ActionResult ReBrandingOutlet()
        {
            return View();
        }

        public ActionResult BrandOutletView()
        {
            return View();
        }


        public JsonResult GetRetailers(string term)
        {
            var list = new List<Retailer>();
            try
            {
                list = _brandOutletManager.GetRetailers(term).ToList();
            }
            catch (Exception ex)
            {

            }
            var objstate = list.Select(x => new { value = x.RetailerName, Id = x.Id, Address = x.RetailerAddress, Phone = x.PhoneNumber }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetOutetRetailers(string term)
        {
            var list = new List<BrandOutletMaster>();
            try
            {
                list = _brandOutletManager.GetOutetRetailers(term).ToList();
            }
            catch (Exception ex)
            {

            }
            var objstate = list.Select(x => new { value = x.RetailerName, Id = x.Id, Address = x.RetailerAddress, Phone = x.RetailerPhone,Token=x.OutletToken }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }




        public JsonResult GetBrandCategoryDetails(string term)
        {
            var list = new List<BrandMonitorCategory>();
            try
            {
                list = _brandOutletManager.GetBrandCategoryDetails(term).ToList();
            }
            catch (Exception ex)
            {

            }
            var objstate = list.Select(x => new { value = x.Name, Id = x.Id }).ToList();
            return Json(objstate.ToArray(), JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetBrandSubCategory(long id)
        {
            var list = new List<BrandMonitorSubCategory>();
            try
            {
                list = _brandOutletManager.GetBrandSubCategory(id).ToList();
            }
            catch (Exception ex)
            {

            }
            //var objstate = list.Select(x => new { value = x.Name, Id = x.Id }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public JsonResult BrandOutletDetails(Guid? token)
        {
            var list = new List<BrandOutletDetail>();
            try
            {
                list = _brandOutletManager.BrandOutletDetails(token).ToList();
            }
            catch (Exception ex)
            {

            }
            
            return Json(list, JsonRequestBehavior.AllowGet);
        }




        public JsonResult InsertNewBrandOutletInfo(List<NewBrandOutletModel> newBrandOutlet)
        {
            var brandOutletMasterResult = new Result();
            var brandOutletDetail = new Result();
            var brandOutletLog= new Result();
            try
            {

                var tokenNumber = Guid.NewGuid();

                brandOutletMasterResult = _brandOutletManager.InsertNewBrandOutletMasterInfo(newBrandOutlet, tokenNumber);

                //if (brandOutletMasterResult.IsSuccess)
                //{

                //    brandOutletDetail = _brandOutletManager.InsertNewBrandOutletMasterDetailsInfo(newBrandOutlet, tokenNumber);

                //}

                //if (brandOutletDetail.IsSuccess)
                //{

                //    brandOutletLog = _brandOutletManager.InsertNewBrandOutletlogInfo(newBrandOutlet, tokenNumber);

                //}


            }

            catch (Exception ex)
            {

            }
            return Json(brandOutletMasterResult, JsonRequestBehavior.AllowGet);
        }




        public JsonResult InsertReBrandOutletInfo(List<NewBrandOutletModel> reBrandItems, List<NewBrandOutletModel> newBrandItems)
        {
            //var brandOutletMasterResult = new Result();
            var brandOutletDetail = new Result();
            var brandOutletLog = new Result();

            var newbrandOutletDetails = new Result();
            var brandnewOutletLog = new Result();

            try
            {

                brandOutletDetail = _brandOutletManager.UpdateBrandOutletMasterDetailsInfo(reBrandItems);

                if (brandOutletDetail.IsSuccess)
                {
                    var token = reBrandItems[0].Token;
                    if (token != null)
                    {
                        Guid tokenNumber = (Guid)token;
                        brandOutletLog = _brandOutletManager.InsertNewBrandOutletlogInfo(reBrandItems, tokenNumber);
                    }
                }

                if (brandOutletLog.IsSuccess && newBrandItems.Count > 0)
                {
                    var token = reBrandItems[0].Token;
                    if (token != null)
                    {
                        var tokenNumber = (Guid)token;
                        newbrandOutletDetails = _brandOutletManager.InsertNewBrandOutletMasterDetailsInfo(newBrandItems, tokenNumber);
                    }
                }
                if (newbrandOutletDetails.IsSuccess && newBrandItems.Count > 0)
                {
                    var token = reBrandItems[0].Token;
                    if (token != null)
                    {
                        var tokenNumber = (Guid)token;
                        brandnewOutletLog = _brandOutletManager.InsertNewBrandOutletlogInfo(newBrandItems, tokenNumber);
                    }
                }
                return Json(brandnewOutletLog, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                brandnewOutletLog.IsSuccess = false;
                return Json(brandnewOutletLog, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult GetBrandOutletMasterDatatable()
        {
            var list = new List<BrandOutletMaster>();
            try
            {
                list = _brandOutletManager.GetBrandOutletMasterDatatable();

            }
            catch (Exception ex)
            {

            }

            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BrandOutletDetailsData(Guid? id)
        {
            var _entities = new BrandOutletMonitoringEntities();

            var brandOutletDetails = _entities.BrandOutletDetails.ToList();

            ViewBag.Brandoutlet = brandOutletDetails;

            return View();
        }

    }
}