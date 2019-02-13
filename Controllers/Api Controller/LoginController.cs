using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BrandOutlet.Models.Custom_Api_Models;
using BrandOutlet.Models.EntityModel;

namespace BrandOutlet.Controllers.Api_Controller
{
    public class LoginController : ApiController
    {

        [HttpGet]
        public Credentials GetLoginInfo()
        {
            var credentials = new Credentials();
            var entities = new BrandOutletMonitoringEntities();
           
            return credentials;
        }


        [HttpGet]
        public Credentials GetLoginInfo(string mobileNumber, string password)
        {
            var credentials = new Credentials();

            using (var entities = new BrandOutletMonitoringEntities())
            {


                var userDate =
                    entities.BrandLogins.FirstOrDefault(
                        a => a.Mobile == mobileNumber && a.Password == password && a.Active == true);

                if (userDate != null)
                {
                    credentials.status = "1";
                    credentials.employeeid = userDate.Id.ToString();
                    credentials.phoneNumber = userDate.Mobile;
                    credentials.usertype = userDate.UserType;

                }


                else
                {
                    credentials.status = "0";

                    credentials.errormsg = "Invalid Username/Password";

                }


            }

            return credentials;

        }
    }
}
