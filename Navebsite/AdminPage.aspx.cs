using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavebsiteBL;

namespace Navebsite
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sales.Sales = Sales.AllStats();
            GameGrid.DataSource = Game.ReviewGames();
            GameGrid.DataBind();
        }
    }
}