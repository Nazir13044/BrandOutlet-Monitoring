using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BrandOutlet.CustomModel;
using BrandOutlet.Manager;
using BrandOutlet.Models.EntityModel;
using Brand_Monitor;
using WCMS_MAIN.HelperClass;

namespace BrandOutlet.Controllers
{
    public class AdminController : Controller
    {
       

        #region Fields

        private readonly BrandIssueManager _brandIssueManager;//= new BrandIssueManager();
        private readonly AdminManager _adminManager;
        private readonly BrandingIssueSolvedManager _brandingIssueSolvedManager;
        private readonly BrandingTeamManager _brandingTeamManager;
        private readonly BrandManager _brandManager;
        private readonly BrandOutletManager _brandOutletManager;
        Dictionary<int, SessionData> _sessiondictionary = SessionData.GetSessionValues();
        
        
        #endregion

        #region Ctor
        public AdminController( )
        {
            _brandIssueManager = new BrandIssueManager();
            _adminManager = new AdminManager();
            _brandingIssueSolvedManager =new BrandingIssueSolvedManager();
            _brandingTeamManager = new BrandingTeamManager();
            _brandManager = new BrandManager();
            _brandOutletManager = new BrandOutletManager();

        }


        #endregion









        public ActionResult ImageUploader()
        {           
            return View();
        }

        public ActionResult MonitoringIssues()
        {
            return View();
        }
        public JsonResult InsertImage(ImageViewModel model)
        {
            var result = new Result();
            result = _adminManager.InsertImage(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

       

       
        //public ActionResult DiisplayingImage(int id)
        //{
        //    var img = new List<tblImageUploader>();
        //    try
        //    {
        //        img = _adminManager.DisplayingImage(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return File(img.ImageId, "image/jpg");
        //    //return File(list, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult DisplayingImage(int imgid)
        {
            var db = new BrandOutletMonitoringEntities();


            var img = db.tblImageUploaders.SingleOrDefault(x => x.Id == imgid);
            return File(img.ImageByte, "image/jpg");
        }
       
    }
}