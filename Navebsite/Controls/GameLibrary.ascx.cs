using System;
using System.Collections.Generic;
using System.Web.UI;
using NavebsiteBL;

namespace Navebsite.Controls
{
    public partial class GameLibrary : UserControl
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