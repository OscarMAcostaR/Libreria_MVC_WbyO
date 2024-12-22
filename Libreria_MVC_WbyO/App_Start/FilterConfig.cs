using System.Web;
using System.Web.Mvc;

namespace Libreria_MVC_WbyO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
