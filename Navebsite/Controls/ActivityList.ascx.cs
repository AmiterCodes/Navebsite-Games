using NavebsiteBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Navebsite.Controls
{
    public partial class ActivityList : System.Web.UI.UserControl
    {
        public List<Activity> Activities { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ItemsList.DataSource = Activities;
                ItemsList.DataBind();
            }
        }
    }
}