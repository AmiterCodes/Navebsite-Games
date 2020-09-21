using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavebsiteBL;

namespace Navebsite
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Register_Click(object sender, EventArgs e)
        {

            Validate();
            if (!IsValid) return;
            var userName = username.Text;
            var pass = password.Text;

            var user = NavebsiteBL.User.RegisterUser(userName, pass);
            if (user == null)
            {
                errorBox.Text = "Register did not work";
            } else
            {
                Session["user"] = user;
                user.AddActivity("Created Account");
                Response.Redirect("Profile.aspx?id=" + user.Id);
            }
        }
    }
}