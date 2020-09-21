using System;
using System.Collections.Generic;
using NavebsiteBL;

namespace Navebsite.Controls
{
    public partial class GameList : System.Web.UI.UserControl
    {

        public List<Game> Games { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                ItemsList.DataSource = Games;
                ItemsList.DataBind();
            }
        }
    }
}