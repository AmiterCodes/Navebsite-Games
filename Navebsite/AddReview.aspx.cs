using NavebsiteBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Navebsite
{
    public partial class AddReview : System.Web.UI.Page
    {
        Game game;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || string.IsNullOrEmpty(Request.QueryString["game"]))
            {
                Response.Redirect("Store");
                return;
            }
            if(!int.TryParse(Request.QueryString["game"], out int gameId))
            {
                Response.Redirect("Store");
                return;
            }
            game = new Game(gameId);
            reviewTitle.Text = game.GameName + " Review";
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (Request.Form["demo"] == null) return;
            string unparsedRating = Request.Form["demo"];
            if(!int.TryParse(unparsedRating, out int rating))
            {
                errorBox.Text = "You entered an invalid rating!";
            } else
            {
                User user = (User)Session["user"];
                Review review = new Review(reviewContent.Text, int.Parse(Request.QueryString["game"]), user.Id, rating);
                
            }

        }
    }
}