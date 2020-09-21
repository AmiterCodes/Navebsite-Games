using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavebsiteBL;

namespace Navebsite
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var qs = Request.QueryString["id"];
            User user;
            if (qs == null || !int.TryParse(qs, out var id))
            {
                if (Session["user"] != null)
                {
                    user = (User)Session["user"];
                }
                else
                {
                    Response.Redirect("404.aspx");
                    return;
                }
            }
            else
            {
                user = new User(id);
            }
            banner.ImageUrl = user.BackgroundUrl;
            icon.ImageUrl = user.ProfilePictureUrl;
            
            name.Text = Server.HtmlEncode(user.Username);
            activities.Activities = user.Activities;
            friends.Users = Friends.GetFriends(user.Id);
        }
    }
}