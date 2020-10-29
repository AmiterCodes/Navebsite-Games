using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavebsiteBL;

namespace Navebsite
{
    public partial class DeveloperPage : System.Web.UI.Page
    {
        private Developer dev;
        protected void Page_Load(object sender, EventArgs e)
        {

            dev = (Developer)Session["dev"];

            if (dev == null) Response.Redirect("404");

            games.Games = Game.GamesByDeveloper(dev.Id);

            salesChart.Sales = Sales.CompanyStats(dev.Id);
        }


    }
}