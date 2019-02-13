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
    public class BrandingTeamManager
    {
    private readonly IBrandingTeam iBrandingTeam = new BrandingTeamRepository();


    public Result InsertBrandingTeamInfo(tblBrandingTeam brandingTeam)
    {
        var result = new Result();
        try
        {
            result.IsSuccess = iBrandingTeam.InsertBrandingTeamInfo(brandingTeam);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return result;
    }


        public List<tblBrandingTeam> GetBrandingTeamListDatatable()
        {
            try
            {
                return iBrandingTeam.GetBrandingTeamListDatatable();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public tblBrandingTeam EditBrandingTeamListById(long id)
        {
            try
            {
                return iBrandingTeam.EditBrandingTeamListById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result UpadteBrandingTeamInfo(tblBrandingTeam brandingInfo)
        {
            var result = new Result();
            try
            {
                result.IsSuccess = iBrandingTeam.UpadteBrandingTeamInfo(brandingInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        public Result InsertBrandingMonitoringTeamInfo(tblBrandingMonitoringTeam brandingMonitoringTeam)
        {
            var result = new Result();
            try
            {
                result.IsSuccess = iBrandingTeam.InsertBrandingMonitoringTeamInfo(brandingMonitoringTeam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public List<tblBrandingMonitoringTeam> GetBrandingMonitoringTeamListDatatable()
        {
            try
            {
                return iBrandingTeam.GetBrandingMonitoringTeamListDatatable();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public tblBrandingMonitoringTeam EditBrandingMonitoringTeamListById(long id)
        {
            try
            {
                return iBrandingTeam.EditBrandingMonitoringTeamListById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Result UpadteBrandingMonitoringTeamInfo(tblBrandingMonitoringTeam brandingMonitoringInfo)
        {
            var result = new Result();
            try
            {
                result.IsSuccess = iBrandingTeam.UpadteBrandingMonitoringTeamInfo(brandingMonitoringInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
   
    }
}