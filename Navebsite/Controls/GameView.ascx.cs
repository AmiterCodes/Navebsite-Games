using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavebsiteBL;

namespace Navebsite.Controls
{
    public partial class GameView : System.Web.UI.UserControl
    {
        public Game Game { get; set;  }
        public bool AddButtons { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            buttons.Visible = AddButtons;

            GameViewPanel.Style["background"] =
                $"linear-gradient(180deg, rgba(15, 16, 22, 0.72) 0, #1C1D2B 100%), url(../{Game.BackgroundUrl}) center/cover";
            PublishedDate.Text = Game.PublishDate.ToShortDateString();
            GameDeveloper.Text = Game.DeveloperName;
            GameGenres.Text = Game.GenresString;
            GameName.Text = Game.GameName;
            Sales sales = Sales.SalesForGame(Game.Id);
            revenue.Text = "$" + sales.Revenue;
            sold.Text = "" + sales.Purchases;

            GameName.NavigateUrl = "../GamePage.aspx?id=" + Game.Id;
            EditButton.NavigateUrl = "../EditGame.aspx?game=" + Game.Id;
            rating.Text = Game.AverageRating + "⭐";
            price.Text = Game.Price == 0 ? "Free" : "$" + Game.Price;
        }

        protected void DenyButton_OnClick(object sender, EventArgs e)
        {
            Game.ReviewStatus = 2;
            Parent.Controls.Remove(this);
        }

        protected void ApproveButton_OnClick(object sender, EventArgs e)
        {
            Game.ReviewStatus = 1;

            List<Game> games = (List<Game>) Application["StoreGames"];
            games.Add(Game);
            Parent.Controls.Remove(this);
        }
    }
}