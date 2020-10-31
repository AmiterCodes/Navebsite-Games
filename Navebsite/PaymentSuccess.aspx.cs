using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Navebsite
{
    public partial class PaymentSuccess : System.Web.UI.Page
    {
        private bool code = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            string key = Request.QueryString["key"];

            if (key != null)
            {
                code = true;
                Code.Text = key;
            }
        }
    }
}