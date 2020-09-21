using System;
using System.IO;
using System.Configuration;
using NavebsiteBL;
using System.Web.Routing;

namespace Navebsite
{
        public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(Server.MapPath("~/"));
            BlHelper.SetPath(ConfigurationManager.AppSettings["DbPath"]);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}