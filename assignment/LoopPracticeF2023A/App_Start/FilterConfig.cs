using System.Web;
using System.Web.Mvc;

namespace LoopPracticeF2023A
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
