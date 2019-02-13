using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandOutlet.CustomModel;
using BrandOutlet.Manager;
using BrandOutlet.Models.EntityModel;

namespace BrandOutlet.Controllers
{
    public class BrandIssueController : Controller
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
        public BrandIssueController()
        {
            _brandIssueManager = new BrandIssueManager();
            _adminManager = new AdminManager();
            _brandingIssueSolvedManager = new BrandingIssueSolvedManager();
            _brandingTeamManager = new BrandingTeamManager();
            _brandManager = new BrandManager();
            _brandOutletManager = new BrandOutletManager();

        }


        #endregion




        public ActionResult Index()
        {
            //var _entities = new BrandOutletMonitoringEntities();

            //var img = (from v in _entities.BrandingIssues

            //           join brandsub in _entities.BrandMonitorSubCategories on v.SubCategoryid equals brandsub.Id
            //           join brandcat in _entities.BrandMonitorCategories on v.BrandId equals brandcat.Id

            //           where v.Active==true
            //           select new BrandingIssueModel
            //           {
            //               Id = v.Id,
            //               BrandSubCategory = brandsub.Name,
            //               BrandCategory = brandcat.Name,
            //               RetailerPhone =v.RetailerMobile,
            //               RetailerAddress = v.RetailerAddress,
            //               Description = v.Description,
            //               IssueFile = v.IssueFile

            //           }).ToList();

            //foreach (var item in img)
            //{
            //    item.IssueFile = GetFile(item.IssueFile);
            //    item.FileExtension = GetExtension(item.IssueFile);

            //}






            //ViewBag.Datas = img;

            return View();
        }


        public ActionResult BrandIssueIgnoreToday()
        {
            return View();
        }

        public string GetFile(string path)
        {
            //const string webServerFilePath = @"C:\uploads\1\2\3\";


            const string webServerFilePath = @"../../Content/UploadImage";




            var fileName = Path.GetFileName(path);
            try
            {
                if (path != null)
                {
                    if (fileName == null) return null;



                    //System.Web.HttpContext.Current.Request.MapPath(webServerFilePath), fileName);


                    string webServerFileName = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(webServerFilePath), fileName);
                    if (!System.IO.File.Exists(webServerFileName))
                    {
                        System.IO.File.Copy(path, webServerFileName, true);
                    }
                }
                return webServerFilePath + "/" + fileName;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }



        public string GetExtension(string path)
        {
            var filePath = path;
            string extension = Path.GetExtension(filePath);
            return extension;
        }


        public ActionResult BrandIssuedView()
        {
            return View();
        }



        public ActionResult BrandIssueSolved()
        {
            return View();
        }

        public ActionResult BrandTrashDatatable()
        {
            return View();
        }


        public ActionResult GetIssueDetails(Guid? id)
        {
            var _entities = new BrandOutletMonitoringEntities();


            var brandissueDetails = (from v in _entities.BrandIssueMasters
                                     join brandsub in _entities.BrandMonitorSubCategories on v.SubCategoryId equals brandsub.Id
                                     join brandcat in _entities.BrandMonitorCategories on v.CategoryId equals brandcat.Id
                                     where v.IssueId == id && v.Active == true
                                     select new BrandingIssueModel
                                     {

                                         IssueId = v.IssueId,
                                         BrandSubCategory = brandsub.Name,
                                         BrandCategory = brandcat.Name,
                                         RetailerPhone = v.RetailersPhone,
                                         RetailerAddress = v.RetailersAddress,
                                         Description = v.Description,




                                     }).ToList();


            var img = (from v in _entities.BrandingIssues

                       where v.BrandIssueId == id
                       select new BrandingIssueModel
                       {

                           IssueFile = v.IssueFile

                       }).ToList();

            foreach (var item in img)
            {
                item.IssueFile = GetFile(item.IssueFile);
                item.FileExtension = GetExtension(item.IssueFile);

            }





            ViewBag.Datas = img;
            ViewBag.BrandIssue = brandissueDetails;



            return View();
        }


        public ActionResult GetIssueSolvedDetails(Guid? id)
        {
            var _entities = new BrandOutletMonitoringEntities();


            var brandissueDetails = (from v in _entities.BrandIssueMasters
                                     join brandsub in _entities.BrandMonitorSubCategories on v.SubCategoryId equals brandsub.Id
                                     join brandcat in _entities.BrandMonitorCategories on v.CategoryId equals brandcat.Id
                                     where v.IssueId == id && v.Solved == true
                                     select new BrandingIssueModel
                                     {

                                         IssueId = v.IssueId,
                                         BrandSubCategory = brandsub.Name,
                                         BrandCategory = brandcat.Name,
                                         RetailerPhone = v.RetailersPhone,
                                         RetailerAddress = v.RetailersAddress,
                                         Description = v.Description,




                                     }).ToList();

            var brandIssueSolvedDetails = (from v in _entities.BrandingIssuesSolveds
                                           where v.IssueId == id

                                           select new BrandingIssueModel
                                           {

                                               IssueId = v.IssueId,
                                               Remarks = v.Remarks,
                                               Solutions = v.Solutions,
                                               AddedBy = v.AddedBy,
                                               AddedDate = v.AddedDate,

                                           }).ToList();


            var img = (from v in _entities.BrandingIssues

                       where v.BrandIssueId == id
                       select new BrandingIssueModel
                       {

                           IssueFile = v.IssueFile

                       }).ToList();

            foreach (var item in img)
            {
                item.IssueFile = GetFile(item.IssueFile);
                item.FileExtension = GetExtension(item.IssueFile);

            }





            ViewBag.Datas = img;
            ViewBag.brandIssueSolved = brandIssueSolvedDetails;
            ViewBag.BrandIssue = brandissueDetails;



            return View();
        }

        public ActionResult GetIssueTrashDetails(Guid? id)
        {
            var _entities = new BrandOutletMonitoringEntities();


            var brandissueDetails = (from v in _entities.BrandIssueMasters
                                     join brandsub in _entities.BrandMonitorSubCategories on v.SubCategoryId equals brandsub.Id
                                     join brandcat in _entities.BrandMonitorCategories on v.CategoryId equals brandcat.Id
                                     where v.IssueId == id && v.Trash == true
                                     select new BrandingIssueModel
                                     {

                                         IssueId = v.IssueId,
                                         BrandSubCategory = brandsub.Name,
                                         BrandCategory = brandcat.Name,
                                         RetailerPhone = v.RetailersPhone,
                                         RetailerAddress = v.RetailersAddress,
                                         Description = v.Description,




                                     }).ToList();


            var img = (from v in _entities.BrandingIssues

                       where v.BrandIssueId == id
                       select new BrandingIssueModel
                       {

                           IssueFile = v.IssueFile

                       }).ToList();

            foreach (var item in img)
            {
                item.IssueFile = GetFile(item.IssueFile);
                item.FileExtension = GetExtension(item.IssueFile);

            }





            ViewBag.Datas = img;
            ViewBag.BrandIssue = brandissueDetails;



            return View();
        }

        public ActionResult GetIssueDetailsPrevious(Guid? id)
        {
            var _entities = new BrandOutletMonitoringEntities();


            var brandissueDetails = (from v in _entities.BrandIssueMasters
                                     join brandsub in _entities.BrandMonitorSubCategories on v.SubCategoryId equals brandsub.Id
                                     join brandcat in _entities.BrandMonitorCategories on v.CategoryId equals brandcat.Id
                                     where v.IssueId == id && v.Active == true
                                     select new BrandingIssueModel
                                     {

                                         IssueId = v.IssueId,
                                         BrandSubCategory = brandsub.Name,
                                         BrandCategory = brandcat.Name,
                                         RetailerPhone = v.RetailersPhone,
                                         RetailerAddress = v.RetailersAddress,
                                         Description = v.Description,




                                     }).ToList();


            var img = (from v in _entities.BrandingIssues

                       where v.BrandIssueId == id
                       select new BrandingIssueModel
                       {

                           IssueFile = v.IssueFile

                       }).ToList();

            foreach (var item in img)
            {
                item.IssueFile = GetFile(item.IssueFile);
                item.FileExtension = GetExtension(item.IssueFile);

            }





            ViewBag.Datas = img;
            ViewBag.BrandIssue = brandissueDetails;



            return View();
        }


        public JsonResult GetBrandIssueForDatatable()
        {
            var list = new List<BrandingIssueModel>();
            try
            {
                list = _brandIssueManager.GetBrandIssueForDatatable();

            }
            catch (Exception ex)
            {

            }

            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetBrandIssueSolvedDatatable()
        {
            var list = new List<BrandingIssueModel>();
            try
            {
                list = _brandIssueManager.GetBrandIssueSolvedDatatable();

            }
            catch (Exception ex)
            {

            }

            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBrandTrashForDatatable()
        {
            var list = new List<BrandingIssueModel>();
            try
            {
                list = _brandIssueManager.GetBrandTrashForDatatable();

            }
            catch (Exception ex)
            {

            }

            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBrandIssueBeforeDetails()
        {
            var list = new List<BrandingIssueModel>();
            try
            {
                list = _brandIssueManager.GetBrandIssueBeforeDetails();

            }
            catch (Exception ex)
            {

            }

            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }












    }
}