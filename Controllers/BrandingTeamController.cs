using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandOutlet.Manager;
using BrandOutlet.Models.EntityModel;
using Brand_Monitor;

namespace BrandOutlet.Controllers
{
    public class BrandingTeamController : Controller
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
        public BrandingTeamController ()
        {
            _brandIssueManager =new BrandIssueManager();
            _adminManager = new AdminManager();
            _brandingIssueSolvedManager = new BrandingIssueSolvedManager();
            _brandingTeamManager = new BrandingTeamManager();
            _brandManager = new BrandManager();
            _brandOutletManager = new BrandOutletManager();

        }


        #endregion




        public ActionResult BrandingTeam()
        {
            return View();
        }
        public ActionResult BrandingMonitoringTeam()
        {
            return View();
        }
        public JsonResult InsertBrandingTeamInfo(tblBrandingTeam brandingTeam)
        {
            var result = new Result();
            brandingTeam.AddedDate = DateTime.Now;
            brandingTeam.Active = true;
            try
            {
                result = _brandingTeamManager.InsertBrandingTeamInfo(brandingTeam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(result);
        }
        public JsonResult GetBrandingTeamListDatatable()
        {
            var list = new List<tblBrandingTeam>();
            try
            {
                list = _brandingTeamManager.GetBrandingTeamListDatatable();

            }
            catch (Exception ex)
            {

            }

            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditBrandingTeamListById(long id)
        {
            tblBrandingTeam brand;
            try
            {
                brand = _brandingTeamManager.EditBrandingTeamListById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(brand,JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpadteBrandingTeamInfo(tblBrandingTeam brandingInfo,string type)
        {
            var result = new Result();
            if (type == "E")
            {
                brandingInfo.UpdatedDate = DateTime.Now;
                result = _brandingTeamManager.UpadteBrandingTeamInfo(brandingInfo);
            }
            else
            {
                brandingInfo.DeletedDate = DateTime.Now;
                result = _brandingTeamManager.UpadteBrandingTeamInfo(brandingInfo);
            }
            return Json(result);
        }
        public JsonResult InsertBrandingMonitoringTeamInfo(tblBrandingMonitoringTeam brandingMonitoringTeam)
        {
            var result = new Result();
            brandingMonitoringTeam.AddedDate = DateTime.Now;
            brandingMonitoringTeam.Active = true;
            try
            {
                result = _brandingTeamManager.InsertBrandingMonitoringTeamInfo(brandingMonitoringTeam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(result);
        }
        public JsonResult GetBrandingMonitoringTeamListDatatable()
        {
            var list = new List<tblBrandingMonitoringTeam>();
            try
            {
                list = _brandingTeamManager.GetBrandingMonitoringTeamListDatatable();

            }
            catch (Exception ex)
            {

            }

            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditBrandingMonitoringTeamListById(long id)
        {
            tblBrandingMonitoringTeam brand;
            try
            {
                brand = _brandingTeamManager.EditBrandingMonitoringTeamListById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(brand, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpadteBrandingMonitoringTeamInfo(tblBrandingMonitoringTeam brandingMonitoringInfo, string type)
        {
            var result = new Result();
            if (type == "E")
            {
                brandingMonitoringInfo.Updateddate = DateTime.Now;
                result = _brandingTeamManager.UpadteBrandingMonitoringTeamInfo(brandingMonitoringInfo);
            }
            else
            {
                brandingMonitoringInfo.DeletedDate = DateTime.Now;
                result = _brandingTeamManager.UpadteBrandingMonitoringTeamInfo(brandingMonitoringInfo);
            }
            return Json(result);
        }
	}
}