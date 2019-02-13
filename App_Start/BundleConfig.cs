using System.Web;
using System.Web.Optimization;

namespace BrandOutlet
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/bundles/bootstrapcss").Include("~/Plugins/vendors/bootstrap/dist/css/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/bundles/Customcss").Include("~/Plugins/build/css/custom.min.css"));
            bundles.Add(new StyleBundle("~/bundles/fontawesomecss").Include( "~/Plugins/vendors/font-awesome/css/font-awesome.min.css"));
                  

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Plugins/vendors/jquery/dist/jquery.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include("~/Plugins/vendors/bootstrap/dist/js/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/prog").Include("~/Plugins/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/custom").Include("~/Plugins/build/js/custom.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryDataTable").Include("~/Plugins/vendors/Datatables/jquery.dataTable-1.10.9.min.js"));

           

        }
    }
}
