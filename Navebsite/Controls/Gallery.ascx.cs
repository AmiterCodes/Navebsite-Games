using System;
using System.Collections.Generic;
using System.Web.UI;
using NavebsiteBL;

namespace Navebsite.Controls
{
    public partial class Gallery : UserControl
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