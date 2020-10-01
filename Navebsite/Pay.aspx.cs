using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Navebsite.CreditWebService;
using NavebsiteBL;
using static Navebsite.CreditWebService.CreditWebService;

namespace Navebsite
{
    public partial class Pay : System.Web.UI.Page
    {
        private Game game;
        private double amount;
        private string payingFor;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var user = (User) Session["user"];
                if (user == null) Response.Redirect("Login.aspx");

                string amountString = Request.QueryString["am"];
                payingFor = Request.QueryString["for"];

                if (amountString == null || payingFor == null) Response.Redirect("404");
                if (!double.TryParse(amountString, out amount)) Response.Redirect("404");

                if (payingFor != "game" && payingFor != "bal") Response.Redirect("404");

                switch (payingFor)
                {
                    case "bal":
                    {
                        if (amount < 5 || amount > 1000) amount = 5;
                        break;
                    }
                    case "game":
                    {
                        string gameIdString = Request.QueryString["game"];
                        if (gameIdString == null) Response.Redirect("404");
                        if (!int.TryParse(gameIdString, out int gameId)) Response.Redirect("404.aspx");

                        game = new Game(gameId);
                        amount = game.Price;
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
                Response.Redirect("404");
            }
        }

        protected void PayButton_OnClick(object sender, EventArgs e)
        {
            var user = (User)Session["user"];
            if (user == null) Response.Redirect("Login.aspx");
            CreditWebService.CreditWebService service = new CreditWebService.CreditWebService();
            CreditCardDetails details = new CreditCardDetails
            {
                CardNumber = cardnumber.Text,
                CardVerificationValue = securitycode.Text,
                HolderName = name.Text,
                Month = int.Parse(expirationdate.Text.Substring(0, 2)),
                Year = int.Parse(expirationdate.Text.Substring(2, 2))
            };

            var transaction = service.Pay(details, "Navebsite Games Inc.", amount);
            if (transaction == null)
            {
                ErrorBox.Text = "Payment Failed";
                return;
            }

            if (payingFor == "bal")
            {
                user.UpdateBalance(amount + user.Balance);

            }

            if (payingFor == "game")
            {
                UserGame.
            }
        }
    }
}