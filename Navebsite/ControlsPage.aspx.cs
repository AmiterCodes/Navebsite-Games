using System;
using System.Web.UI;

namespace Navebsite
{
    public partial class ControlsPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userList.Users = NavebsiteBL.User.AllUsers();
        }
    }
}