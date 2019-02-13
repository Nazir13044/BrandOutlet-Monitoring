using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandOutlet.Models.EntityModel;

namespace BrandOutlet.Interface
{
    interface IBrandingIssuesSolved
    {
        bool InsertBrandingIssueSolvedInfo(BrandingIssuesSolved brandingIssue);
        bool UpadteBrandingIssueSolvedInfo(BrandIssueMaster brandingIssue);
    }
}
