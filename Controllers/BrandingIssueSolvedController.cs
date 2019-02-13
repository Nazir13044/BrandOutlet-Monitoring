using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandOutlet.Manager;
using BrandOutlet.Models.EntityModel;
using Brand_Monitor;

namespace BrandOutlet.Controllers
{
    public class BrandingIssueSolvedController : Controller
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
        public BrandingIssueSolvedController()
        {
            _brandIssueManager =new BrandIssueManager();
            _adminManager =new AdminManager();
            _brandingIssueSolvedManager =new BrandingIssueSolvedManager();
            _brandingTeamManager = new BrandingTeamManager();
            _brandManager = new BrandManager();
            _brandOutletManager = new BrandOutletManager();

        }


        #endregion

        
        public JsonResult InsertBrandingIssueSolvedInfo(BrandingIssuesSolved brandingIssue, string status)
        {
            var result = new Result();
            var upresult = new Result();
            var bIssues = new BrandIssueMaster();
            if (status.ToLower() == "completed")
            {

                brandingIssue.AddedDate = DateTime.Now;
                brandingIssue.AddedBy = 1;
                result = _brandingIssueSolvedManager.InsertBrandingIssueSolvedInfo(brandingIssue);


                if (result.IsSuccess)
                {

                    bIssues.IssueId = brandingIssue.IssueId;
                    bIssues.SolvedDate = DateTime.Now;
                    bIssues.SolvedBy = brandingIssue.AddedBy;
                    bIssues.Active = false;
                    bIssues.Solved = true;
                    upresult = _brandingIssueSolvedManager.UpadteBrandingIssueSolvedInfo(bIssues);
                }

                if (upresult.IsSuccess)

                {

                    TempData["success"] = "Completed Successfully";
                }


        }

            if (status.ToLower() == "trash")
            {
                bIssues.IssueId = brandingIssue.IssueId;
                bIssues.TrashDate = DateTime.Now;
                bIssues.TrashBy = brandingIssue.AddedBy;
                bIssues.Trash = true;
                bIssues.Active = false;
                upresult = _brandingIssueSolvedManager.UpadteBrandingIssueSolvedInfo(bIssues);

                if (upresult.IsSuccess)
                {

                    TempData["success"] = "Moved To Trash  Successfully";
                }



            }

            if (status.ToLower() == "trashactive")
            {
                bIssues.IssueId = brandingIssue.IssueId;
                bIssues.ReActiveDate = DateTime.Now;
                bIssues.ReActiveBy = brandingIssue.AddedBy;
                bIssues.Trash = false;
                bIssues.Active = true;
                upresult = _brandingIssueSolvedManager.UpadteBrandingIssueSolvedInfo(bIssues);

                if (upresult.IsSuccess)
                {

                    TempData["success"] = "Moved To Trash  Successfully";
                }



            }






            try
            {
               
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(upresult);
        }





	}
}