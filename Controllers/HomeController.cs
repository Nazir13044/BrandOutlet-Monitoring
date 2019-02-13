using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandOutlet.Manager;

namespace BrandOutlet.Controllers
{
    public class HomeController : Controller
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
        public HomeController()
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
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}