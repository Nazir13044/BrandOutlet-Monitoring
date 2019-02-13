using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BrandApi.Models.Custom_Models;
using BrandOutlet.Models.EntityModel;

namespace BrandApi.Controllers
{
    public class BrandSubCategoryController : ApiController
    {

        [HttpGet]
        public BrandSubCategoryModel GetSalesReport()
        {
            var subCategory = new BrandSubCategoryModel();
            var entities = new BrandOutletMonitoringEntities();
            // credentials.Data = _entities.tblProductRegistrations.ToList();
            return subCategory;
        }


        [HttpGet]
        public BrandSubCategoryModel[] GetSubCategoryModels(string categoryId)
        {


            try
            {


                using (var bmEntity = new BrandOutletMonitoringEntities())
                {

                    var id=Convert.ToInt64(categoryId);

                    var subCategoryList = bmEntity.BrandMonitorSubCategories.Where(a => a.BrandMonitorId == id).ToList();

                    var list = new List<BrandSubCategoryModel>();

                    foreach (var items in subCategoryList)
                    {
                        var br = new BrandSubCategoryModel();
                        br.id = items.Id.ToString();
                        br.subcategoryname = items.Name;
                        br.brandmonitorid = items.BrandMonitorId.ToString();
                        br.duration = (items.Duration + "-" + items.DurationType);
                        br.active = items.Active.ToString();
                        br.validityover = items.ValidityOver.ToString();
                        list.Add(br);

                    }



                    return list.ToArray();

                }

            }
            catch (Exception ex)
            {
                throw new CultureNotFoundException("Error Occured While Getting Information");

            }
        }









    }
}
