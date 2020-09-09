using NavebsiteBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Navebsite
{
    public partial class GamePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["id"]);
                Game game = new Game(id);
                banner.Style["background"] = $"linear-gradient(180deg,rgba(255,255,255,0) -46.84%,#3F3148 100%), url('{game.BackgroundUrl}') center/cover";
                play.Text = "Play " + Server.HtmlEncode(game.GameName);
                gallery.Photos = GamePhoto.PhotosByGame(id).Cast<Photo>().ToList();
                name.Text = Server.HtmlEncode(game.GameName);

                List<Review> list = Review.ReviewsByGame(id);
                foreach(Review review in list)
                {
                    Controls.Review reviewControl = (Controls.Review)Page.LoadControl("~/Controls/Review.ascx");
                reviewControl.review = review;

                    reviewList.Controls.Add(reviewControl);
                }
            } catch(Exception ex)
            {
                Response.Redirect("404.aspx");
            } 
        }

        protected void play_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            Game game = new Game(id);
            Response.Redirect(game.GameLink);
        }
    }
}