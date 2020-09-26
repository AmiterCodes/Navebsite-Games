using System;
using System.Web.UI;

namespace Navebsite
{
    public partial class Logout : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Store");
        }
    }
}