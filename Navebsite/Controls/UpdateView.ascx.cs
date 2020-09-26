using System;
using System.Web.UI;
using NavebsiteBL;

namespace Navebsite.Controls
{
    public partial class UpdateView : UserControl
    {
        public Update Update { get; set; }
        public bool Minified { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}