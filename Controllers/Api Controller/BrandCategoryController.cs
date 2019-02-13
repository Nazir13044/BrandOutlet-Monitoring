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
    public class BrandCategoryController : ApiController
    {
        [HttpGet]
        public BrandCategory[] GetOffersModelPrice()
        {


            try
            {


                using (var bpEntity = new BrandOutletMonitoringEntities())
                {
                    
                    var cellPhonePricingList = bpEntity.BrandMonitorCategories.ToList();

                    var list = new List<BrandCategory>();

                    foreach (var brandMonitorCategory in cellPhonePricingList)
                    {
                        var br = new BrandCategory();
                        br.name = brandMonitorCategory.Name;
                        br.type = brandMonitorCategory.Type;
                        br.id = brandMonitorCategory.Id.ToString();
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
