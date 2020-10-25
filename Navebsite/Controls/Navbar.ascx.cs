using System;
using System.Web.UI;
using NavebsiteBL;

namespace Navebsite.Controls
{
    public partial class Navbar : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (User) Session["user"];
            logout.Visible = false;
            login.Visible = false;
            register.Visible = false;
            library.Visible = false;
            if (Session["user"] != null)
            {
                ProfilePicture.ImageUrl = "../" + user.ProfilePictureUrl;
                ProfileName.Text = user.Username;
                balance.Text = "$" + user.Balance;
                logout.Visible = true;
                logoutSide.Visible = true;
                library.Visible = true;
                userSettingsSide.Visible = true;
            }
            else
            {
                registerSide.Visible = true;
                register.Visible = true;
                loginSide.Visible = true;
                login.Visible = true;
            }
        }
    }
}