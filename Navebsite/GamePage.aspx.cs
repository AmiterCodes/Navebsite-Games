using NavebsiteBL;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace Navebsite
{
    public partial class GamePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(Request.QueryString["id"]);
                var game = new Game(id);
                banner.Style["background"] = $"linear-gradient(180deg,rgba(255,255,255,0) -46.84%,#3F3148 100%), url('{game.BackgroundUrl}') center/cover";
                play.Text = "Buy " + game.GameName + " $" + game.Price;   
                gallery.Photos = GamePhoto.PhotosByGame(id).Cast<Photo>().ToList();
                name.Text = Server.HtmlEncode(game.GameName);


                var list = Review.ReviewsByGame(id);
                foreach(var review in list)
                {
                    var reviewControl = (Controls.Review)Page.LoadControl("~/Controls/Review.ascx");
                reviewControl.ReviewObject = review;
                    reviewControl.ID = ""+review.UserId;
                    reviewList.Controls.Add(reviewControl);
                }

                if (Session["user"] != null)
                {
                    var user = (User)Session["user"];
                    if(UserGame.GameOwnedByUser(game.Id, user.Id))
                    {

                        play.Text = "Play " + Server.HtmlEncode(game.GameName);
                    }
                    var link = new HyperLink
                    {
                        NavigateUrl = "AddReview.aspx?game=" + game.Id,
                        CssClass = "button",
                        Text = "Add Review"
                    };
                    reviewContainer.Controls.Add(link);
                }

            } catch(Exception)
            {
                Response.Redirect("404.aspx");
            } 
        }

        protected void play_Click(object sender, EventArgs e)
        {
            var id = int.Parse(Request.QueryString["id"]);
            var game = new Game(id);
            
            Response.Redirect(game.GameLink);
        }
    }
}