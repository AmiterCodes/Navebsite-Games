using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavebsiteBL;

namespace Navebsite.Controls
{
    public partial class GameList : System.Web.UI.UserControl
    {

        public List<Game> games { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                ItemsList.DataSource = games;
                ItemsList.DataBind();
            }
        }
    }
}