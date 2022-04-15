using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OEE
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        //protected void Application_BeginRequest()
        //{
        //    var loadbalancerReceivedSslRequest = string.Equals(Request.Headers["X-Forwarded-Proto"], "https");
        //    var serverReceivedSslRequest = Request.IsSecureConnection;

        //    if (loadbalancerReceivedSslRequest || serverReceivedSslRequest) return;

        //    UriBuilder uri = new UriBuilder(Context.Request.Url);
        //    if (!uri.Host.Equals("localhost"))
        //    {
        //        uri.Port = 443;
        //        uri.Scheme = "https";
        //        Response.Redirect(uri.ToString());
        //    }
        //}
    }
}
