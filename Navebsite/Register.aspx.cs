using System;
using System.Web.UI;
using NavebsiteBL;

namespace Navebsite
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DevDetails.Visible = NewDevCheck.Checked;
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
                if (NewDevCheck.Checked)
                {
                    Developer developer = new Developer(DevName.Text);

                    Session["dev"] = developer;

                    developer.AddUser(user.Id);
                    user.DeveloperId = developer.Id;
                    user.IsDeveloper = true;
                }
                Session["user"] = user;
                user.AddActivity("Created Account");
                Response.Redirect("Profile.aspx?id=" + user.Id);
            }

            
        }
    }
}