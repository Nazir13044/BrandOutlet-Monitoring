using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BrandApi.Models.Custom_Models;
using BrandOutlet.Models.EntityModel;

namespace BrandOutlet.Controllers.Api_Controller
{
    public class RetailersController : ApiController
    {

        [HttpGet]
        public RetailersInfo[] GetRetailersInfo()
        {


            try
            {


                using (var bmEntity = new RetailerMotivationProgramEntities())
                {



                    var retailersList = bmEntity.Retailers.Where(a => a.IsActive == true).ToList();

                    var list = new List<RetailersInfo>();

                    foreach (var items in retailersList)
                    {
                        var br = new RetailersInfo();
                        br.distributorcode = items.DistributorCode;
                        br.distributorname = items.DistributorName;
                        br.retailername = items.RetailerName;
                        br.retaileraddress = items.RetailerAddress;
                        br.retailerphone = items.PhoneNumber;
                        br.retailerdetail = items.RetailerName + "-" + items.PhoneNumber;
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
