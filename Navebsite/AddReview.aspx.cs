using NavebsiteBL;
using System;

namespace Navebsite
{
    public partial class AddReview : System.Web.UI.Page
    {
        Game _game;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || string.IsNullOrEmpty(Request.QueryString["game"]))
            {
                Response.Redirect("Store");
                return;
            }
            if(!int.TryParse(Request.QueryString["game"], out var gameId))
            {
                Response.Redirect("Store");
                return;
            }
            _game = new Game(gameId);
            reviewTitle.Text = _game.GameName + " Review";
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (Request.Form["demo"] == null) return;
            var unparsedRating = Request.Form["demo"];
            if(!int.TryParse(unparsedRating, out var rating))
            {
                errorBox.Text = "You entered an invalid rating!";
            } else
            {
                var user = (User)Session["user"];
                var review = new Review(reviewContent.Text, int.Parse(Request.QueryString["game"]), user.Id, rating);
                Response.Redirect("GamePage.aspx?id=" + review.GameId);
            }

        }
    }
}