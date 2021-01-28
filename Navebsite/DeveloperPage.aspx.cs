using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Navebsite.App_Code;
using NavebsiteBL;

namespace Navebsite
{
    public partial class DeveloperPage : System.Web.UI.Page
    {
        private Developer dev;
        protected void Page_Load(object sender, EventArgs e)
        {

            dev = (Developer)Session["dev"];

            if (dev == null) Response.Redirect("404");

            games.Games = Game.GamesByDeveloper(dev.Id);

            salesChart.Sales = Sales.CompanyStats(dev.Id);

            DeveloperNameField.Text = dev.DeveloperName;
            AboutField.Text = dev.About;
        }


        protected void UploadProfile_OnClick(object sender, EventArgs e)
        {
            Validate("ProfilePicture");
            if (!IsValid) return;
            var dev = (Developer)Session["dev"];
            if (dev == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            string filename = UploadHelper.ImageFileUpload(ProfilePicture, "Images/DeveloperIcons/", "profile.png", Server);
            dev.UpdateIcon(filename);
            Response.Redirect("DeveloperPage.aspx");
        }

        protected void UploadBackground_OnClick(object sender, EventArgs e)
        {
            Validate("Background");
            if (!IsValid) return;
            var dev = (Developer)Session["dev"];
            if (dev == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            string filename = UploadHelper.ImageFileUpload(Background, "Images/DeveloperBackgrounds/", "no.png", Server);
            dev.UpdateBackground(filename);
            Response.Redirect("DeveloperPage.aspx");

        }

        protected void SubmitData_OnClick(object sender, EventArgs e)
        {
            Validate("DeveloperData");
            if (!IsValid) return;
            var user = (User)Session["user"];
            if (user == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            Response.Redirect("DeveloperPage.aspx");

        }
    }
}