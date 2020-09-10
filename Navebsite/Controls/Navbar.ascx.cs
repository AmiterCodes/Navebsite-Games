using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavebsiteBL;

namespace Navebsite.Controls
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            welcome.Text = "";
            User user = (User)Session["user"];
            profile.Visible = false;
            logout.Visible = false;
            login.Visible = false;
            register.Visible = false;
            if (Session["user"] != null)
            {
                welcome.Text = "Ahoy, " + user.Username;
                profile.Visible = true;
                logout.Visible = true;
            } else
            {
                register.Visible = true;
                login.Visible = true;
            }
        }

    }
}