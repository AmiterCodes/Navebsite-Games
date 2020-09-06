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
            string userName = username.Text;
            string pass = password.Text;

            User user = NavebsiteBL.User.RegisterUser(userName, pass);
            if(user == null) 
            Session["user"] = user;
        }
    }
}