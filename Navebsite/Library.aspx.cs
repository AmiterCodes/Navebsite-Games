using System;
using System.Web.UI;
using NavebsiteBL;

namespace Navebsite
{
    public partial class Library : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("Store.aspx");
            var user = (User) Session["user"];
            library.Games = UserGame.UserGames(user.Id);
        }
    }
}