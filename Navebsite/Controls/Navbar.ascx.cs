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
                logout.Visible = true;
                library.Visible = true;
            }
            else
            {
                register.Visible = true;
                login.Visible = true;
            }
        }
    }
}