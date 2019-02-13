using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandOutlet.Models.EntityModel;
using Brand_Monitor;

namespace BrandOutlet.Interface
{
    interface IBrandingTeam
    {       
        bool InsertBrandingTeamInfo(tblBrandingTeam brandingTeam);
        List<tblBrandingTeam> GetBrandingTeamListDatatable();
        tblBrandingTeam EditBrandingTeamListById(long id);
        bool UpadteBrandingTeamInfo(tblBrandingTeam brandingInfo);
        bool InsertBrandingMonitoringTeamInfo(tblBrandingMonitoringTeam brandingMonitoringTeam);
        List<tblBrandingMonitoringTeam> GetBrandingMonitoringTeamListDatatable();
        tblBrandingMonitoringTeam EditBrandingMonitoringTeamListById(long id);
        bool UpadteBrandingMonitoringTeamInfo(tblBrandingMonitoringTeam brandingMonitoringInfo);
    }
}
