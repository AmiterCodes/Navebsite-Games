using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavebsiteBL;

namespace Navebsite.Controls
{
    public partial class Navbar : UserControl
    {
        private const bool debugMode = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (debugMode) return;
            var user = (User) Session["user"];
            logout.Visible = false;
            login.Visible = false;
            register.Visible = false;
            devPage.Visible = false;
            library.Visible = false;
            adminPage.Visible = false;
            requestsSide.Visible = false;
            if (user != null)
            {
                int friendRequests = Connections.IncomingFriendRequestsCount(user.Id);
                int devRequests = Connections.IncomingDeveloperRequestsCount(user.Id);

                int notifCount = friendRequests + devRequests;

                notifs.Text = notifCount +"";
                if(notifCount > 0)notifs.Visible = true;

                ProfilePicture.ImageUrl = "../" + user.ProfilePictureUrl;
                ProfileName.Text = user.Username;
                balance.Text = "$" + user.Balance;
                logout.Visible = true;
                requestsSide.Visible = true;
                logoutSide.Visible = true;
                library.Visible = true;
                userSettingsSide.Visible = true;
                if (Session["dev"] != null)
                {
                    devPage.Visible = true;
                }

                if (Session["admin"] != null)
                {
                    adminPage.Visible = true;
                }

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