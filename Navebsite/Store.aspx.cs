using System;
using System.Web.UI;
using NavebsiteBL;

namespace Navebsite
{
    public partial class Store : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gm.Games = Game.StoreGames();
            }
        }
    }
}