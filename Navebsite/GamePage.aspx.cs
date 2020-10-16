using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavebsiteBL;

namespace Navebsite
{
    public partial class GamePage : Page
    {
        private Game game;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(Request.QueryString["id"]);
                game = new Game(id);
                banner.Style["background"] =
                    $"linear-gradient(180deg,rgba(255,255,255,0) -46.84%,#3F3148 100%), url('{game.BackgroundUrl}') center/cover";
                play.Text = "Buy " + game.GameName + " $" + game.Price;
                gallery.Photos = GamePhoto.PhotosByGame(id).Cast<Photo>().ToList();
                name.Text = Server.HtmlEncode(game.GameName);


                var list = Review.ReviewsByGame(id);
                foreach (var review in list)
                {
                    var reviewControl = (Controls.Review) Page.LoadControl("~/Controls/Review.ascx");
                    reviewControl.ReviewObject = review;
                    reviewControl.ID = "" + review.UserId;
                    reviewList.Controls.Add(reviewControl);
                }

                UpdateList.Updates = game.Updates;

                if (Session["user"] != null)
                {
                    var user = (User) Session["user"];

                    friends.Users = Friends.FriendsThatPlayGame(user.Id, game.Id);
                    if (UserGame.GameOwnedByUser(game.Id, user.Id))
                        play.Text = "Play " + Server.HtmlEncode(game.GameName);
                    var link = new HyperLink
                    {
                        NavigateUrl = "AddReview.aspx?game=" + game.Id,
                        CssClass = "button",
                        Text = "Add Review"
                    };
                    reviewList.Controls.Add(link);
                }
                else
                {
                    friends.Users = new List<User>();
                    friends.Visible = false;
                }
            }
            catch (Exception)
            {
                Response.Redirect("404.aspx");
            }
        }

        protected void play_Click(object sender, EventArgs e)
        {
            var user = (User)Session["user"];
            
            if(user == null) Response.Redirect("Login.aspx");

            if (UserGame.GameOwnedByUser(game.Id, user.Id))
            {
                Response.Redirect(game.GameLink);
            }
            else
            {
                Response.Redirect($"Pay.aspx?for=game&game={game.Id}");
            }

        }
    }
}