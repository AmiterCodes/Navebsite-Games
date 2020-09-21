using NavebsiteBL;
using System;
using System.Collections.Generic;

namespace Navebsite.Controls
{
    public partial class Gallery : System.Web.UI.UserControl
    {

        public List<Photo> Photos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            ItemsList.DataSource = Photos;
            ItemsList.DataBind();
        }
    }
}