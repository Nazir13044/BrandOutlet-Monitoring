using System.Web;
using System.Web.Mvc;
using WCMS_MAIN.HelperClass;

namespace BrandOutlet
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {

            filters.Add(new UserAuthorization());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
