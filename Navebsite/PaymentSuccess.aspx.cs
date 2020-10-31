using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Navebsite.App_Code;

namespace Navebsite
{
    public partial class PaymentSuccess : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string key = Request.QueryString["code"];
            string game = Request.QueryString["game"];
            string balance = Request.QueryString["balance"];

            if (key != null)
            {
                CodePanel.Visible = true;
                Code.Text = EncodingHelper.Base64Decode( HttpUtility.UrlDecode(key));
            }

            if (game != null && int.TryParse(game, out int gameId))
            {
                GamePanel.Visible = true;
                PlayHere.NavigateUrl = "./GamePage.aspx?id=" + gameId;
            }

            if (balance != null && double.TryParse(balance, out double amount))
            {
                BalancePanel.Visible = true;
                AmountAdded.Text = "$" + amount + " Has been added to your balance!";
            }
        }
    }
}