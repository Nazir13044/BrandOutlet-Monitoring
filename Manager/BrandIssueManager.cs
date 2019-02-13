using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrandOutlet.CustomModel;
using BrandOutlet.Interface;
using BrandOutlet.Repository;

namespace BrandOutlet.Manager
{
    public class BrandIssueManager
    {
        IBrandIssue iBrandIssueRepository = new BrandIssueRepository();


        public List<BrandingIssueModel> GetBrandIssueForDatatable()
        {
            try
            {
                //IBrand iBrandIssueRepository = new BrandRepository();
                return iBrandIssueRepository.GetBrandIssueForDatatable();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<BrandingIssueModel> GetBrandIssueSolvedDatatable()
        {
            try
            {
                //IBrand iBrandIssueRepository = new BrandRepository();
                return iBrandIssueRepository.GetBrandIssueSolvedDatatable();
            }
            catch (Exception ex) { throw ex; }
        }
        public List<BrandingIssueModel> GetBrandTrashForDatatable()
        {
            try
            {
                //IBrand iBrandIssueRepository = new BrandRepository();
                return iBrandIssueRepository.GetBrandTrashForDatatable();
            }
            catch (Exception ex) { throw ex; }
        }
        public List<BrandingIssueModel> GetBrandIssueBeforeDetails()
        {
            try
            {
                //IBrand iBrandIssueRepository = new BrandRepository();
                return iBrandIssueRepository.GetBrandIssueBeforeDetails();
            }
            catch (Exception ex) { throw ex; }
        }

    }
}