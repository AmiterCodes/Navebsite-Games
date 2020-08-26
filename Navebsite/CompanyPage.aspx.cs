using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavebsiteBL;


namespace Navebsite
{
    public partial class CompanyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dev = Request.QueryString["dev"];
            if (dev == null) Response.Redirect("Store.aspx");
            bool success = int.TryParse(dev, out int devId);
            if(!success) Response.Redirect("Store.aspx");
            list.games = Game.GamesByDeveloper(devId);
            Developer developer = new Developer(devId);
            icon.ImageUrl = developer.IconUrl;
            banner.ImageUrl = developer.BackgroundUrl;
            name.Text = developer.DeveloperName;
            gallery.Photos = GamePhoto.PhotosByDeveloper(devId).Cast<Photo>().ToList();
        }
    }
}