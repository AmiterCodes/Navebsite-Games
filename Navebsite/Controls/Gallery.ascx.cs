using NavebsiteBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Navebsite.Controls
{
    public partial class Gallery : System.Web.UI.UserControl
    {

        public List<Photo> Photos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ItemsList.DataSource = Photos;
                ItemsList.DataBind();
            }
        }
    }
}