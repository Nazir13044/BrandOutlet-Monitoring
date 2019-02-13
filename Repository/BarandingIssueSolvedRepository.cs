using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BrandOutlet.Interface;
using BrandOutlet.Models.EntityModel;

namespace BrandOutlet.Repository
{
    public class BarandingIssueSolvedRepository : IBrandingIssuesSolved
    {
        /// <summary>
        /// Model Entities 
        /// </summary>

        private readonly BrandOutletMonitoringEntities _entities; 
        public BarandingIssueSolvedRepository()
        {
            _entities = new BrandOutletMonitoringEntities();
            
        }
        protected void EntityDispose()
        {

            _entities.Dispose();
        }


        public bool InsertBrandingIssueSolvedInfo(BrandingIssuesSolved brandingIssue)
        {
            try
            {
                

                _entities.BrandingIssuesSolveds.Add(brandingIssue);
                _entities.SaveChanges();


                return true;
            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                EntityDispose();
            }
        }

        public bool UpadteBrandingIssueSolvedInfo(BrandIssueMaster branding)
        {

            try
            {
                var brandings = _entities.BrandIssueMasters.FirstOrDefault(x => x.IssueId == branding.IssueId);
                if (brandings != null)
                {
                    if (branding.AddedBy != null)
                        brandings.AddedBy = branding.AddedBy;

                    if (branding.AddedDate != null)
                        brandings.AddedDate = branding.AddedDate;

                    if (branding.SolvedBy != null)
                        brandings.SolvedBy = branding.SolvedBy;


                    if (branding.SolvedDate != null)
                        brandings.SolvedDate = branding.SolvedDate;


                    if (branding.TrashBy != null)
                        brandings.TrashBy = branding.TrashBy;


                    if (branding.TrashBy != null)
                        brandings.TrashDate = branding.TrashDate;



                    if (branding.ReActiveBy != null)
                        brandings.ReActiveBy = branding.ReActiveBy;


                    if (branding.ReActiveDate != null)
                        brandings.ReActiveDate = branding.ReActiveDate;
                   
                    if (branding.Active != null)
                        brandings.Active = branding.Active;

                    if (branding.Trash != null)
                        brandings.Trash = branding.Trash;

                    if (branding.Seen != null)
                        brandings.Seen = branding.Seen;

                    if (branding.Solved != null)
                        brandings.Solved = branding.Solved;

                    _entities.Entry(brandings).State = EntityState.Modified;
                    _entities.SaveChanges();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {

                throw exception;
            }

            //finally
            //{

            //    EntityDispose(true);

            //}




            
            return true;
        } 
    }
}