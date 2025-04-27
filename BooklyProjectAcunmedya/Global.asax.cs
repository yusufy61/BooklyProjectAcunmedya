using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BooklyProjectAcunmedya
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalFilters.Filters.Add(new AuthorizeAttribute()); // Bu işlem sayesinde tüm sayfalara yetkilendirme vermiş olduk.
            //yani tüm proje authorize oldu. Burada default controller da authorize oldu ki biz bunu istemiyoruz. Bunun için gerekli ayarı default controller içerisinde yaptık
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
