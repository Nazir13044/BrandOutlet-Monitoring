using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using WCMS.Models.Login;
//using AuditoERP.Web.Areas.Admin.ViewModels;
using WCMS_MAIN.Models;

namespace WCMS_MAIN.HelperClass
{
    public class UserAuthorization : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (new HttpRequestWrapper(System.Web.HttpContext.Current.Request).IsAjaxRequest())
            {
                return true;
            }


            var controller = httpContext.Request.RequestContext.RouteData.Values["controller"].ToString();
            var action = httpContext.Request.RequestContext.RouteData.Values["action"].ToString();
            if (action.ToLower() == "login" && controller.ToLower() == "account") return true;
            if (action.ToLower() == "logout" && controller.ToLower() == "account") return true;
            if (action.ToLower() == "index" && controller.ToLower() == "home") return true;
            //if (action.ToLower() == "authfailed" && controller.ToLower() == "home") return true;
            var userName = (string)httpContext.Request.RequestContext.HttpContext.Session["BrandLoginUserName"];
            if (userName == "Admin") return true;
            if (httpContext.Request.RequestContext.HttpContext.Session != null && httpContext.Request.RequestContext.HttpContext.Session["permissions"] != null)
            {
                var permissions = (List<MenuModel>)httpContext.Request.RequestContext.HttpContext.Session["permissions"];
                return HttpContext.Current.User.Identity.Name == "1" || Authorize(permissions, controller, action);
            }
            return false;
        }

        private bool Authorize(List<MenuModel> permissions, string controller, string action)
        {
            
            if (permissions.Any())
            {
                int index = permissions.FindIndex(i => i.ControllerName == controller && i.ActionName == action);
                return index >= 0;
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.ActionName.ToLower() == "logout" && filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower() == "account")
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
            }
            else if (filterContext.ActionDescriptor.ActionName.ToLower() == "login" && filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower() == "login")
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
            }
            else if (filterContext.ActionDescriptor.ActionName.ToLower() == "index" && filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower() == "home")
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
            }
            else if (filterContext.ActionDescriptor.ActionName.ToLower() == "authfailed" && filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower() == "Account")
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
            }
            else
            {
                if (filterContext.RequestContext.HttpContext.Session == null) return;
                var logInInfo = (List<MenuModel>)filterContext.RequestContext.HttpContext.Session["permissions"];
                filterContext.Result = logInInfo == null ? new RedirectResult("~/Account/LogIn") : new RedirectResult("~/Home/Index");
            }
        }
    }
}