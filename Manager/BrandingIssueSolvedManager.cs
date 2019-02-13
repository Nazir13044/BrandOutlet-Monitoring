using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrandOutlet.Interface;
using BrandOutlet.Models.EntityModel;
using BrandOutlet.Repository;
using Brand_Monitor;

namespace BrandOutlet.Manager
{
    public class BrandingIssueSolvedManager 
    {
        IBrandingIssuesSolved iBrandingIssuesSolved = new BarandingIssueSolvedRepository();
        public Result InsertBrandingIssueSolvedInfo(BrandingIssuesSolved brandingIssue)
        {

            var result = new Result();
            try
            {
                result.IsSuccess = iBrandingIssuesSolved.InsertBrandingIssueSolvedInfo(brandingIssue);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        public Result UpadteBrandingIssueSolvedInfo(BrandIssueMaster brandingIssue)
        {

            var result = new Result();
            try
            {
                result.IsSuccess = iBrandingIssuesSolved.UpadteBrandingIssueSolvedInfo(brandingIssue);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }




    }
}