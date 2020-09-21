using NavebsiteBL;
using System;

namespace Navebsite
{
    public partial class Library : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("Store.aspx");
            var user = (User)Session["user"];
            library.Games = UserGame.UserGames(user.Id);
        }
    }
}