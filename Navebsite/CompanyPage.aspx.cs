using System;
using System.Linq;
using System.Web.UI;
using NavebsiteBL;

namespace Navebsite
{
    public partial class CompanyPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dev = Request.QueryString["dev"];
            if (dev == null) Response.Redirect("Store.aspx");
            var success = int.TryParse(dev, out var devId);
            if (!success) Response.Redirect("Store.aspx");
            list.Games = Game.GamesByDeveloper(devId);
            var developer = new Developer(devId);
            icon.ImageUrl = developer.IconUrl;
            banner.ImageUrl = developer.BackgroundUrl;
            name.Text = Server.HtmlEncode(developer.DeveloperName);
            gallery.Photos = GamePhoto.PhotosByDeveloper(devId).Cast<Photo>().ToList();
        }
    }
}