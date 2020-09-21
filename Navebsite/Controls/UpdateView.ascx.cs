
using Markdig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Navebsite.Controls
{
    public partial class UpdateView : System.Web.UI.UserControl
    {

        public NavebsiteBL.Update Update { get; set; }
        public bool Minified { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}