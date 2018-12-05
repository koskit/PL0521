using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace Lab4Website
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["UserCount"] = 0;
            Application["ButtonClicks"] = 0;

        }

        void Session_Start(object sender, EventArgs e)
        {
            Application["UserCount"] = Convert.ToUInt32(Application["UserCount"]) + 1;
            Session["ButtonClicks"] = 0;
        }

        void Session_End(object sender, EventArgs e)
        {
            Application["UserCount"] = Convert.ToUInt32(Application["UserCount"]) - 1;
        }
    }
}