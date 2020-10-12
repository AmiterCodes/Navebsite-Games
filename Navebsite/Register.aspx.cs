using System;
using System.Web.UI;

namespace Navebsite
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            Validate();
            if (!IsValid) return;
            var email = Email.Text;
            var userName = username.Text;
            var pass = password.Text;

            var user = NavebsiteBL.User.RegisterUser(email, userName, pass);
            if (user == null)
            {
                errorBox.Text = "Register did not work";
            }
            else
            {
                Session["user"] = user;
                user.AddActivity("Created Account");
                Response.Redirect("Profile.aspx?id=" + user.Id);
            }
        }
    }
}