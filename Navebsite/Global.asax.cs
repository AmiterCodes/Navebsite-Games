using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Routing;
using NavebsiteBL;

namespace Navebsite
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(Server.MapPath("~/"));
            BlHelper.SetPath(ConfigurationManager.AppSettings["DbPath"]);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
             
            

            List<Game> games = Game.StoreGames();
            Application["StoreGames"] = games;
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