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

            

            payment.Visible = !UseBalance.Checked;
            try
            {
                var user = (User) Session["user"];
                if (user == null) Response.Redirect("Login.aspx");

                string amountString = Request.QueryString["am"];
                payingFor = Request.QueryString["for"];

                
                

                if (payingFor != "game" && payingFor != "bal") Response.Redirect("404");

                switch (payingFor)
                {
                    case "bal":
                    {
                        if (!double.TryParse(amountString, out amount)) Response.Redirect("404");
                        if (amountString == null || payingFor == null) Response.Redirect("404");
                        if (amount < 5 || amount > 1000) amount = 5;
                        break;
                    }
                    case "game":
                    {
                        gameOptions.Visible = true;
                        string gameIdString = Request.QueryString["game"];
                        if (gameIdString == null) Response.Redirect("404");
                        if (!int.TryParse(gameIdString, out int gameId)) Response.Redirect("404.aspx");

                        game = new Game(gameId);
                        amount = game.Price;

                        double remaining = user.Balance - amount;

                        CurrentBalance.Text = user.Balance + "";
                        RemainingBalance.Text = remaining + "";

                        if (remaining < 0)
                        {
                            UseBalance.Enabled = false;
                            UseBalance.Text = "(not enough balance)";
                        }


                            break;
                    }
                }

                paymentAmount.Text = "$" + amount;
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
            var service = new CreditWebService.CreditWebService();
            var details = new CreditCardDetails
            {
                CardNumber = cardnumber.Text.Replace(" ",""),
                CardVerificationValue = securitycode.Text,
                HolderName = name.Text,
                Month = int.Parse(expirationdate.Text.Substring(0, 2)),
                Year = int.Parse(expirationdate.Text.Substring(3, 2))
            };

            var transaction = service.Pay(details, "Navebsite Games Inc.", amount);
            if (transaction == null)
            {
                ErrorBox.Text = "Payment Failed";
                return;
            }

            switch (payingFor)
            {
                case "bal":
                    user.UpdateBalance(amount + user.Balance);
                    Response.Redirect("UserSettings.aspx");
                    break;
                case "game":
                    UserGame.AddGame(user.Id, game.Id, amount);
                    Response.Redirect("GamePage.aspx?id=" + game.Id);
                    break;
            }
        }

        protected void UseBalance_OnCheckedChanged(object sender, EventArgs e)
        {
            payment.Visible = !UseBalance.Checked;
        }
    }
}