using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BrandOutlet.Interface;
using BrandOutlet.Models.EntityModel;
using Brand_Monitor;

namespace BrandOutlet.Repository
{
    public class BrandingTeamRepository : IBrandingTeam
    {
        private readonly BrandOutletMonitoringEntities _entities=new BrandOutletMonitoringEntities();
      
        public bool InsertBrandingTeamInfo(tblBrandingTeam brandingTeam)
        {
            try
            {

                _entities.tblBrandingTeams.Add(brandingTeam);
                _entities.SaveChanges();

                return true;
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public List<tblBrandingTeam> GetBrandingTeamListDatatable()
        {
            List<tblBrandingTeam> List;
            try
            {
                List = _entities.tblBrandingTeams.Where(x=>x.Active==true).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return List;
        }

        public tblBrandingTeam EditBrandingTeamListById(long id)
        {
            tblBrandingTeam brand;
            try
            {
                brand = _entities.tblBrandingTeams.FirstOrDefault(x=>x.Id==id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return brand;
        }

        public bool UpadteBrandingTeamInfo(tblBrandingTeam brandingInfo)
        {
            tblBrandingTeam brandingInfoes = _entities.tblBrandingTeams.FirstOrDefault(x => x.Id == brandingInfo.Id);
            if (brandingInfo != null)
            {
                if (brandingInfo.Name != null)
                    if (brandingInfoes != null) brandingInfoes.Name = brandingInfo.Name;
                if (brandingInfo.EmployeeId != null)
                    if (brandingInfoes != null) brandingInfoes.EmployeeId = brandingInfo.EmployeeId;
                if (brandingInfo.MobileNumber != null)
                    if (brandingInfoes != null) brandingInfoes.MobileNumber = brandingInfo.MobileNumber;
                if (brandingInfo.Email != null)
                    if (brandingInfoes != null) brandingInfoes.Email = brandingInfo.Email;
                if (brandingInfo.Active != null)
                    if (brandingInfoes != null) brandingInfoes.Active = brandingInfo.Active;
                if (brandingInfo.UpdatedDate != null)
                    if (brandingInfoes != null) brandingInfoes.UpdatedDate = brandingInfo.UpdatedDate;
                if (brandingInfo.DeletedDate != null)
                    if (brandingInfoes != null) brandingInfoes.DeletedDate = brandingInfo.DeletedDate;
                _entities.Entry(brandingInfoes).State = EntityState.Modified;
                _entities.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

       

        public bool InsertBrandingMonitoringTeamInfo(tblBrandingMonitoringTeam brandingMonitoringTeam)
        {
             try
            {

                _entities.tblBrandingMonitoringTeams.Add(brandingMonitoringTeam);
                _entities.SaveChanges();

                return true;
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public List<tblBrandingMonitoringTeam> GetBrandingMonitoringTeamListDatatable()
        {
            List<tblBrandingMonitoringTeam> List;
            try
            {
                List = _entities.tblBrandingMonitoringTeams.Where(x => x.Active == true).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return List;
        }

        public tblBrandingMonitoringTeam EditBrandingMonitoringTeamListById(long id)
        {
            tblBrandingMonitoringTeam brand;
            try
            {
                brand = _entities.tblBrandingMonitoringTeams.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return brand;
        }

        public bool UpadteBrandingMonitoringTeamInfo(tblBrandingMonitoringTeam brandingMonitoringInfo)
        {
            tblBrandingMonitoringTeam brandingMonitoringInfoes = _entities.tblBrandingMonitoringTeams.FirstOrDefault(x => x.Id == brandingMonitoringInfo.Id);
            if (brandingMonitoringInfo != null)
            {
                if (brandingMonitoringInfo.Name != null)
                    if (brandingMonitoringInfoes != null) brandingMonitoringInfoes.Name = brandingMonitoringInfo.Name;
                if (brandingMonitoringInfo.EmployeeId != null)
                    if (brandingMonitoringInfoes != null) brandingMonitoringInfoes.EmployeeId = brandingMonitoringInfo.EmployeeId;
                if (brandingMonitoringInfo.MobileNumber != null)
                    if (brandingMonitoringInfoes != null) brandingMonitoringInfoes.MobileNumber = brandingMonitoringInfo.MobileNumber;
                if (brandingMonitoringInfo.Email != null)
                    if (brandingMonitoringInfoes != null) brandingMonitoringInfoes.Email = brandingMonitoringInfo.Email;
                if (brandingMonitoringInfo.Active != null)
                    if (brandingMonitoringInfoes != null) brandingMonitoringInfoes.Active = brandingMonitoringInfo.Active;
                if (brandingMonitoringInfo.Updateddate != null)
                    if (brandingMonitoringInfoes != null) brandingMonitoringInfoes.Updateddate = brandingMonitoringInfo.Updateddate;
                if (brandingMonitoringInfo.DeletedDate != null)
                    if (brandingMonitoringInfoes != null) brandingMonitoringInfoes.DeletedDate = brandingMonitoringInfo.DeletedDate;
                _entities.Entry(brandingMonitoringInfoes).State = EntityState.Modified;
                _entities.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        }
    }
