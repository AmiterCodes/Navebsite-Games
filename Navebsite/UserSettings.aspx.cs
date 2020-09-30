using System;
using System.Web.UI;
using NavebsiteBL;

namespace Navebsite
{
    public partial class UserSettings : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (User)Session["user"];
            if (user == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            Bio.Text = user.Description;
            CurrentBackground.ImageUrl = user.BackgroundUrl;
            CurrentProfilePicture.ImageUrl = user.ProfilePictureUrl;
        }

        protected void UpdateBio_OnClick(object sender, EventArgs e)
        {
            
        }

        protected void UploadImage_OnClick(object sender, EventArgs e)
        {

        }

        protected void UploadProfile_OnClick(object sender, EventArgs e)
        {

        }

        protected void UploadBackground_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void UpdatePassword_OnClick(object sender, EventArgs e)
        {
            var user = (User)Session["user"];
            if (user == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            var authenticatedUser = NavebsiteBL.User.AuthUser(user.Username, OldPassword.Text);
            if (authenticatedUser != null)
            {

            }

        }
    }
}