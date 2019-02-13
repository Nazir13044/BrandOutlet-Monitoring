using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BrandApi.Models.Custom_Models;
using BrandOutlet.Models.EntityModel;


namespace BrandApi.Controllers
{
    public class BrandIssueController : ApiController
    {



        [System.Web.Http.HttpGet]
        public Result GetDescription()
        {
            var subCategory = new Result();
            //var entities = new BrandOutletMonitoringEntities1();
            //// credentials.Data = _entities.tblProductRegistrations.ToList();
            return subCategory;
        }


        [System.Web.Mvc.HttpPost]
        public Result PostDescription()
        {

            var masterResult = new Result();
            var result = new Result();

            var brandingIssue = new BrandingIssue();
            var brandingIssueMaster = new BrandIssueMaster();

            const string initialPath = @"~/Content/UploadImage";


            try
            {
                
                    //****Posted Files
                    //****Posted Files

                    var httpPostedFile = HttpContext.Current.Request.Files;
// ReSharper disable once AssignNullToNotNullAttribute
                    var strings = HttpContext.Current.Request.Form.GetValues("desc").ToList();
                    var stringsAddress = HttpContext.Current.Request.Form.GetValues("add");
                    var stringPhone = HttpContext.Current.Request.Form.GetValues("phone");
                    var stringSubcategoryId = HttpContext.Current.Request.Form.GetValues("subcategoryid");
                    var stringCategoryId = HttpContext.Current.Request.Form.GetValues("categoryid");

                    //Strings Bind

                    //string bind

                    string description = null;
                    string address = null;
                    string phone = null;

                    long? categoryid = null;
                    long? subcategoryid = null;
                    if (strings != null)
                    {
                        description = strings[0];

                    }

                    if (stringsAddress != null)
                    {
                        address = stringsAddress[0];
                    }

                    if (stringPhone != null)
                    {
                        phone = stringPhone[0];
                    }

                    if (stringSubcategoryId != null)
                    {
                        subcategoryid = Convert.ToInt64(stringSubcategoryId[0]);
                    }

                    if (stringCategoryId != null)
                    {
                        categoryid = Convert.ToInt64(stringCategoryId[0]);
                    }



                    //****Posted Files
                    //****Posted Files
                    // Get the uploaded image from the Files collection  
                    // Get the uploaded image from the Files collection  
                    var bmEntity = new BrandOutletMonitoringEntities();

                    var issueToken = Guid.NewGuid();


                    brandingIssueMaster.IssueId = issueToken;
                    brandingIssueMaster.CategoryId = categoryid;
                    brandingIssueMaster.SubCategoryId = subcategoryid;
                    brandingIssueMaster.Description = description;
                    brandingIssueMaster.RetailersPhone = phone;
                    brandingIssueMaster.RetailersAddress = address;
                    brandingIssueMaster.Active = true;
                    brandingIssueMaster.AddedDate = DateTime.Now;

                    bmEntity.BrandIssueMasters.Add(brandingIssueMaster);
                    masterResult.issuccess = bmEntity.SaveChanges();
                    if (masterResult.issuccess == 1)
                    {
                        result.error = false;
                        result.message = "Uploaded Successfully";

                        if (HttpContext.Current.Request.Files.AllKeys.Any())
                        {


                            for (var iCnt = 0; iCnt <= httpPostedFile.Count - 1; iCnt++)
                            {

                                var postedFile = httpPostedFile[iCnt];

                                var fileName = Path.GetFileName(postedFile.FileName);


                                if (fileName != null)
                                {
                                    var todayTime = DateTime.Now;
                                    var time = new DateTime(todayTime.Year, todayTime.Month, todayTime.Day,
                                        todayTime.Hour,
                                        todayTime.Minute, todayTime.Second, todayTime.Millisecond);
                                    var timeFormat = string.Format("{0:yyyy-MM-dd_hh-mm-ss-fff}", time);
                                    fileName = timeFormat + "-" + fileName;
                                    var path = Path.Combine(HttpContext.Current.Server.MapPath(initialPath), fileName);
                                    postedFile.SaveAs(path);


                                    string finalPath = @"C:\uploads" + @"\" + 1 + @"\" + 2 + @"\" + 3;
                                    if (Directory.Exists(finalPath))
                                    {
                                        File.Copy(path, finalPath + "\\" + fileName, true);
                                    }
                                    else
                                    {
                                        Directory.CreateDirectory(finalPath);
                                        File.Copy(path, finalPath + "\\" + fileName, true);
                                    }

                                    brandingIssue.BrandIssueId = issueToken;
                                    brandingIssue.IssueFile = finalPath + "\\" + fileName;
                                    bmEntity.BrandingIssues.Add(brandingIssue);
                                    bmEntity.SaveChanges();

                                    result.error = false;
                                    result.message = "Uploaded Successfully";

                                }

                            }

                        }
                    }

                    else
                    {
                        result.error = true;
                        result.message = "Uploaded Failed";
                    }


                    //var httpPostedFile = HttpContext.Current.Request.Files["upload"];
                    //


                


            }
            catch (Exception)
            {
                result.error = true;
                result.message = "Uploaded Failed";
                
            }


            return result;


        }
    }
}
