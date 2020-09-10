using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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