using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrandOutlet.CustomModel;
using BrandOutlet.Interface;
using BrandOutlet.Models.EntityModel;

namespace BrandOutlet.Repository
{
    public class BrandIssueRepository : IBrandIssue
    {
        private readonly BrandOutletMonitoringEntities _entities = new BrandOutletMonitoringEntities();

        public List<BrandingIssueModel> GetBrandIssueForDatatable()
        {



            DateTime startDateTime = DateTime.Today; //Today at 00:00:00
            DateTime endDateTime = DateTime.Today.AddDays(1).AddTicks(-1);


            List<BrandingIssueModel> list = null;
            try
            {
                //list = _entities.BrandingIssues.Where(x => x.Active == true).ToList(); 
                list = (from branding in _entities.BrandIssueMasters

                        join brandsub in _entities.BrandMonitorSubCategories on branding.SubCategoryId equals brandsub.Id
                        join brandcat in _entities.BrandMonitorCategories on branding.CategoryId equals brandcat.Id

                        where branding.Active == true && branding.AddedDate >= startDateTime && branding.AddedDate <= endDateTime
                        orderby branding.AddedDate descending 
                        select new BrandingIssueModel
                        {
                            IssueId = branding.IssueId,
                            BrandSubCategory = brandsub.Name,
                            BrandCategory = brandcat.Name,
                            RetailerPhone = branding.RetailersPhone,
                            RetailerAddress = branding.RetailersAddress,
                            Description = branding.Description,


                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<BrandingIssueModel> GetBrandIssueSolvedDatatable()
        {
            List<BrandingIssueModel> list = null;
            try
            {
                //list = _entities.BrandingIssues.Where(x => x.Active == true).ToList(); 
                list = (from branding in _entities.BrandIssueMasters

                        join brandsub in _entities.BrandMonitorSubCategories on branding.SubCategoryId equals brandsub.Id
                        join brandcat in _entities.BrandMonitorCategories on branding.CategoryId equals brandcat.Id

                        where branding.Solved == true
                        orderby branding.AddedDate descending
                        select new BrandingIssueModel
                        {
                            IssueId = branding.IssueId,
                            BrandSubCategory = brandsub.Name,
                            BrandCategory = brandcat.Name,
                            RetailerPhone = branding.RetailersPhone,
                            RetailerAddress = branding.RetailersAddress,
                            Description = branding.Description,


                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }


        public List<BrandingIssueModel> GetBrandTrashForDatatable()
        {
            List<BrandingIssueModel> list = null;
            try
            {
                //list = _entities.BrandingIssues.Where(x => x.Active == true).ToList(); 
                list = (from branding in _entities.BrandIssueMasters

                        join brandsub in _entities.BrandMonitorSubCategories on branding.SubCategoryId equals brandsub.Id
                        join brandcat in _entities.BrandMonitorCategories on branding.CategoryId equals brandcat.Id

                        where branding.Trash == true
                        orderby branding.AddedDate descending 
                        select new BrandingIssueModel
                        {
                            IssueId = branding.IssueId,
                            BrandSubCategory = brandsub.Name,
                            BrandCategory = brandcat.Name,
                            RetailerPhone = branding.RetailersPhone,
                            RetailerAddress = branding.RetailersAddress,
                            Description = branding.Description,


                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public List<BrandingIssueModel> GetBrandIssueBeforeDetails()
        {
            DateTime toDay = DateTime.Today;
            List<BrandingIssueModel> list = null;
            try
            {
                //list = _entities.BrandingIssues.Where(x => x.Active == true).ToList(); 
                list = (from branding in _entities.BrandIssueMasters

                        join brandsub in _entities.BrandMonitorSubCategories on branding.SubCategoryId equals brandsub.Id
                        join brandcat in _entities.BrandMonitorCategories on branding.CategoryId equals brandcat.Id

                        where branding.Active == true && branding.AddedDate <= toDay
                        orderby branding.AddedDate descending
                        select new BrandingIssueModel
                        {
                            IssueId = branding.IssueId,
                            BrandSubCategory = brandsub.Name,
                            BrandCategory = brandcat.Name,
                            RetailerPhone = branding.RetailersPhone,
                            RetailerAddress = branding.RetailersAddress,
                            Description = branding.Description,


                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }
        
    }
}