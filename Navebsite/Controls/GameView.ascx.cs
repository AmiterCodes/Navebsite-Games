using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavebsiteBL;

namespace Navebsite.Controls
{
    public partial class GameView : System.Web.UI.UserControl
    {
        public Game Game { get; }

        protected void Page_Load(object sender, EventArgs e)
        { 
            GameViewPanel.Style["background-image"] =
                $"linear-gradient(180deg, rgba(15, 16, 22, 0.72) 0, #1C1D2B 100%), url(../{Game.BackgroundUrl})";
            PublishedDate.Text = Game.PublishDate.ToShortDateString();
            GameDeveloper.Text = Game.DeveloperName;
            GameGenres.Text = Game.GenresString;
            GameName.Text = Game.GameName;
            rating.Text = Game.AverageRating + "⭐";
        }
    }
}