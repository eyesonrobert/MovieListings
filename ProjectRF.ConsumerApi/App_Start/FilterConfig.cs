using System.Web;
using System.Web.Mvc;

namespace ProjectRF.ConsumerApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
