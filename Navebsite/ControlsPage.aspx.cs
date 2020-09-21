using System;

namespace Navebsite
{
    public partial class ControlsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userList.Users = NavebsiteBL.User.AllUsers();
        }
    }
}