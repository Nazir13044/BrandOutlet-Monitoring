using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandOutlet.CustomModel;

namespace BrandOutlet.Interface
{
    interface IBrandIssue
    {
     
        List<BrandingIssueModel> GetBrandIssueForDatatable();
        List<BrandingIssueModel> GetBrandIssueSolvedDatatable();
        List<BrandingIssueModel> GetBrandTrashForDatatable();
        List<BrandingIssueModel> GetBrandIssueBeforeDetails();
    }
}
