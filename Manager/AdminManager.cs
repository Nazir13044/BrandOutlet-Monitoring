using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using BrandOutlet.CustomModel;
using BrandOutlet.Interface;
using BrandOutlet.Repository;
using Brand_Monitor;

namespace BrandOutlet.Manager
{

    public class AdminManager
    {



        #region Fields

        private readonly IAdmin _iAdmin;
        private readonly IBrand _iBrand;
        private readonly IBrandingIssuesSolved _iBranndingIssuesSolved;
        private readonly IBrandingTeam _iBrandingTeam;
        private readonly IBrandIssue _iBrandIssue;
        private readonly IBrandOutlet _iBrandOutlet;

        #endregion

        #region Ctor
        public AdminManager()
        {

            _iAdmin = new AdminRepository();
            _iBrand = new BrandRepository();
            _iBranndingIssuesSolved = new BarandingIssueSolvedRepository();
            _iBrandingTeam = new BrandingTeamRepository();
            _iBrandIssue = new BrandIssueRepository();
            _iBrandOutlet = new BrandOutletRepository();

        }

        #endregion

       



        public Result InsertImage(ImageViewModel model)
        {
            var result = new Result();
            try
            {
                result.IsSuccess = _iAdmin.InsertImage(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        //public List<tblImageUploader> DisplayingImage(long id)
        //{
        //    var list = new List<tblImageUploader>();
        //    try
        //    {
        //        IAdmin iAdmin = new AdminRepository();
        //        return iAdmin.DisplayingImage(id);
        //    }
        //    catch (Exception ex) { throw ex; }


        //}


    }
}