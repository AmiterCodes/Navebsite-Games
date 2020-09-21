using System;

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