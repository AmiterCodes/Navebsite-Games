using System;
using System.Web.UI;

namespace Navebsite
{
    public partial class UserSettings : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void UpdateBio_OnClick(object sender, EventArgs e)
        {
        }

        protected void UploadImage_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void UploadProfile_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void UploadBackground_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}