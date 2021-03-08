using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavebsiteBL;

namespace Navebsite.Controls
{
    public partial class GameViewList : System.Web.UI.UserControl
    {
        public List<Game> Games { get; set; }
        public bool AddButtons { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Games.ForEach(game =>
            {

                GameView view = (GameView) this.Page.LoadControl("~/Controls/GameView.ascx");
                view.AddButtons = AddButtons;
                view.Game = game;
                List.Controls.Add(view);
            });
            if (List.Controls.Count == 1) NoGames.Visible = true;
        }
    }
}