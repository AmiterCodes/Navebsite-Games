using System;
using System.Collections.Generic;
using System.Web.UI;
using NavebsiteBL;

namespace Navebsite.Controls
{
    public partial class GameList : UserControl
    {
        public List<Game> Games { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ItemsList.DataSource = Games;
            ItemsList.DataBind();
        }
    }
}