using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BrandApi.Models.Custom_Models;
using BrandOutlet.Models.EntityModel;

namespace BrandApi.Controllers
{
    public class ImageController : Controller
    {
        //
        // GET: /Image/

        public string GetExtension(string path)
        {
            var filePath = path;
            string extension = Path.GetExtension(filePath);
            return extension;
        }


        


        public ActionResult Index()
        {
            //var _entities = new BrandOutletMonitoringEntities();

            //var img =(from v in _entities.BrandingIssues select new BrandingIssueModel
            //{
            //    Id = v.Id,
            //    Description = v.Description,
            //    IssueFile = v.IssueFile
            //}).ToList();

            //foreach (var item in img)
            //{
            //    item.IssueFile = GetFile(item.IssueFile);
            //    item.FileExtension = GetExtension(item.IssueFile);

            //}




           
            //ViewBag.Datas = img;

            return View();
        }



        public string GetFile(string path)
        {
            const string webServerFilePath = @"../Content/UploadImage";
            var fileName = Path.GetFileName(path);
            try
            {
                if (path != null)
                {
                    if (fileName == null) return null;
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




        public JsonResult GetData()
        {
            var _entities = new BrandOutletMonitoringEntities();

            var img = _entities.BrandingIssues.ToList();

            var jsonResult = Json(img, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }



        public ActionResult RetrieveImage(long id)
        {
            ////byte[] cover = GetImageFromDataBase(id);
            //if (cover != null)
            //{
            //    return File(cover, "image/jpg");
            //}
            //else
            //{
            //    return null;
            //}
            return null;
        }

        //public byte[] GetImageFromDataBase(long Id)
        //{
        //    var _entities = new BrandOutletMonitoringEntities1();
        //    var q = from temp in _entities.BrandingIssues where temp.Id == Id select temp.IssueFile;
        //    //byte[] cover = q.First();
        //    return [s];
        //}
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
        public int UploadImageInDataBase(HttpPostedFileBase file, BrandingIssue contentViewModel)
        {
            var _entities = new BrandOutletMonitoringEntities();
            //contentViewModel.IssueFile = ConvertToBytes(file);
            var Content = new BrandingIssue
            {
                //BrandId = contentViewModel.BrandId,
                //Description = contentViewModel.Description,
                //SubCategoryid = contentViewModel.SubCategoryid,
                IssueFile = contentViewModel.IssueFile
            };
            _entities.BrandingIssues.Add(Content);
            int i = _entities.SaveChanges();
            if (i == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BrandingIssue model)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];
           
            int i = UploadImageInDataBase(file, model);
            if (i == 1)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }




	}
}