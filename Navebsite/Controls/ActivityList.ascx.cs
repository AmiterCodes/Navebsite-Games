using System;
using System.Collections.Generic;
using System.Web.UI;
using NavebsiteBL;

namespace Navebsite.Controls
{
    public partial class ActivityList : UserControl
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