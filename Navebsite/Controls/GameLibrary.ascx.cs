using NavebsiteBL;
using System;
using System.Collections.Generic;

namespace Navebsite.Controls
{
    public partial class GameLibrary : System.Web.UI.UserControl
    {


        public List<UserGame> Games { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ItemsList.DataSource = Games;
                ItemsList.DataBind();
            }
        }
    }
}