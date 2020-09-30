using System;
using System.Collections.Generic;
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
                ViewState["Games"] = Game.StoreGames();
            };

            gm.Games = (List<Game>) ViewState["Games"];
        }
    }
}