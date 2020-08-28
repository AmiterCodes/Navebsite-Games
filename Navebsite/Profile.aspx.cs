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
            string qs = Request.QueryString["id"];
            int id = 0;
            if (qs == null || !int.TryParse(qs, out id)) Response.Redirect("404.aspx");

            User user = new User(id);
            banner.ImageUrl = user.BackgroundUrl;
            icon.ImageUrl = user.ProfilePictureUrl;
            
            name.Text = Server.HtmlEncode(user.Username);
            activities.Activities = user.Activities;
        }
    }
}