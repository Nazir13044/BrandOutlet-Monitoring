using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using BrandOutlet.Manager;
using BrandOutlet.Models.EntityModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using BrandOutlet.Models;
using WCMS_MAIN.Models;

namespace BrandOutlet.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

       
           
        //#region Fields

        //private readonly BrandIssueManager _brandIssueManager;//= new BrandIssueManager();
        //private readonly AdminManager _adminManager;
        //private readonly BrandingIssueSolvedManager _brandingIssueSolvedManager;
        //private readonly BrandingTeamManager _brandingTeamManager;
        //private readonly BrandManager _brandManager;
        //private readonly BrandOutletManager _brandOutletManager;
        
        //#endregion

        //#region Ctor
        //public AccountController
        //    (
        //    BrandIssueManager brandIssueManager,
        //    AdminManager adminManager,
        //    BrandingIssueSolvedManager brandingIssueSolvedManager,
        //    BrandingTeamManager brandingTeamManager,
        //    BrandManager brandManager,
        //    BrandOutletManager brandOutletManager
        //    )
        //{
        //    _brandIssueManager = brandIssueManager;
        //    _adminManager = adminManager;
        //    _brandingIssueSolvedManager = brandingIssueSolvedManager;
        //    _brandingTeamManager = brandingTeamManager;
        //    _brandManager = brandManager;
        //    _brandOutletManager = brandOutletManager;

        //}


        //#endregion


        // GET: /Account/Login
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            Session.Clear();
            Session.Abandon();
            var cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "")
            {
                Expires = DateTime.Now.AddYears(-1)
            };
            Response.Cookies.Add(cookie1);
            var cookie2 = new HttpCookie("ASP.NET_SessionId", "") { Expires = DateTime.Now.AddYears(-1) };
            Response.Cookies.Add(cookie2);
            return View();
        }

        //Login Module


        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn(LoginModel login)
        {


            if (ModelState.IsValid) //validating the user inputs
            {
                bool isExist = false;
                using (var entity = new BrandOutletMonitoringEntities())  // 
                {
                    isExist = entity.BrandLogins.Any(x => x.UserName.Trim().ToLower() == login.UserName.Trim().ToLower() && x.Password == login.Password); //validating the user name in tblLogin table whether the user name is exist or not
                    if (isExist)
                    {
                        var loginCredentials = entity.BrandLogins.Where(x => x.UserName.Trim().ToLower() == login.UserName.Trim().ToLower()).Select(x => new LoginModel
                        {
                            Id = x.Id,
                            UserName = x.UserName,
                            Email = x.Email,
                            Mobile = x.Mobile,
                            EmployeeName = x.Name,
                            EmployeeId = x.EmployeeId,
                            UserRoleId=x.RoleId
                        }).FirstOrDefault();



                        List<MenuModel> menus = entity.BrandSubMenus.Where(x => x.RoleId == loginCredentials.UserRoleId && x.IsMenue == true).Select(x => new MenuModel
                        {
                            MainMenuId = x.BrandMainMenu.Id,
                            MainMenuName = x.BrandMainMenu.MainMenu,
                            SubMenuId = x.Id,
                            SubMenuName = x.SubMenu,
                            ControllerName = x.Controller,
                            ActionName = x.Action,
                            RoleId = x.RoleId
                           


                        }).ToList(); //Get the Menu details 

                        List<MenuModel> permissions = entity.BrandSubMenus.Where(x => x.RoleId == loginCredentials.UserRoleId || x.RoleId == 0).Select(x => new MenuModel
                        {
                            MainMenuId = x.BrandMainMenu.Id,
                            MainMenuName = x.BrandMainMenu.MainMenu,
                            SubMenuId = x.Id,
                            SubMenuName = x.SubMenu,
                            ControllerName = x.Controller,
                            ActionName = x.Action,
                            RoleId = x.RoleId
                            
                        }).ToList(); //Get the Menu details 


                        FormsAuthentication.SetAuthCookie(loginCredentials.UserName, false); // set the formauthentication cookie


                        Session["LoginCredentials"] = loginCredentials; //
                        Session["MenuMaster"] = menus; //
                        Session["permissions"] = permissions; //

                        System.Web.HttpContext.Current.Session["BrandLoginUserId"] = loginCredentials.Id;
                        System.Web.HttpContext.Current.Session["BrandLoginUserName"] = loginCredentials.UserName;
                        System.Web.HttpContext.Current.Session["BrandLoginUserEmployeeId"] = loginCredentials.EmployeeId;
                        System.Web.HttpContext.Current.Session["BrandLoginEmployeeName"] = loginCredentials.EmployeeName;
                        System.Web.HttpContext.Current.Session["BrandLoginEmployeeMobile"] = loginCredentials.Mobile;
                        System.Web.HttpContext.Current.Session["BrandLoginEmployeeEmail"] = loginCredentials.Email;


                        return RedirectToAction("Home", "Brand");

                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Please enter the valid credentials!";
                        return View();
                    }
                }
            }
            return View();

            //return RedirectToAction("Index", "Home");
        }









        //Login Module 

        public ActionResult LogOut()
        {

            //Dictionary<int, SessionData> IDictionary = SessionData.GetSessionValues();
            //long userId = (long)IDictionary[3].Id;
            //var _CommonService = new CommonService();
            //var result = _CommonService.UpdateLastEntry(userId);

            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            FormsAuthentication.SignOut();
            var cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "") { Expires = DateTime.Now.AddYears(-1) };
            Response.Cookies.Add(cookie1);
            var cookie2 = new HttpCookie("ASP.NET_SessionId", "") { Expires = DateTime.Now.AddYears(-1) };
            Response.Cookies.Add(cookie2);
            return RedirectToAction("LogIn");
        }


    }
}