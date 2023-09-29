using System.Web;
using System.Web.Mvc;

namespace n01641589_OwenLaing_Assign1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
