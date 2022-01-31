using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace E2BizzEventManagementSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterTypes(UnityConfig.Container);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_Start()
        {
            Session["UserId"] = string.Empty;
            Application.Lock();
            Application["UserCount"] = Convert.ToInt32(Application["UserCount"]) + 1;
            Application.UnLock();
        }
        protected void Session_End()
        {
            Session["UserId"] = null;
            Application.Lock();
            Application["UserCount"] = Convert.ToInt32(Application["UserCount"]) - 1;
            Application.UnLock();
        }
        protected void Application_End()
        {

        }
    }
}
