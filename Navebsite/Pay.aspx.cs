using System;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using Navebsite.App_Code;
using Navebsite.CreditWebService;

using NavebsiteBL;

namespace Navebsite
{
    public partial class Pay : Page
    {
        private double amount;
        private Game game;
        private string payingFor;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ValidateRequestMode = ValidateRequestMode.Enabled;


            payment.Visible = !UseBalance.Checked;
            try
            {
                var user = (User) Session["user"];
                if (user == null) Response.Redirect("Login.aspx");

                var amountString = Request.QueryString["am"];
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
                        var gameIdString = Request.QueryString["game"];
                        if (gameIdString == null) Response.Redirect("404");
                        if (!int.TryParse(gameIdString, out var gameId)) Response.Redirect("404.aspx");

                        game = new Game(gameId);
                        amount = game.Price;

                        GameImage.ImageUrl = game.BackgroundUrl;
                        GameImage.AlternateText = "Image for " + game.GameName;
                        GameName.Text = game.GameName;

                        PayButton.CausesValidation = !UseBalance.Checked;

                        var remaining = user.Balance - amount;

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
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                Response.Redirect("404");
            }
        }

        protected void PayButton_OnClick(object sender, EventArgs e)
        {
            var user = (User) Session["user"];
            if (user == null) Response.Redirect("Login.aspx");

            if (!UseBalance.Checked)
            {
                var service = new CreditWebService.CreditWebService();
                var details = new CreditCardDto
                {
                    CardNumber = cardnumber.Text.Replace(" ", ""),
                    CardVerificationValue = securitycode.Text,
                    Month = int.Parse(expirationdate.Text.Substring(0, 2)),
                    Year = int.Parse(expirationdate.Text.Substring(3, 2))
                };

                var transaction = service.Pay(details, service.GetBankAccount(3), amount);
                if (transaction == null)
                {
                    SnackbarHelper.DisplaySnackBar(this, "Payment Failed");
                    return;
                }
            }
            else
            {
                user.UpdateBalance(user.Balance - amount);
            }

            string paymentSuccessPage = "./PaymentSuccess.aspx";
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            switch (payingFor)
            {
                case "bal":
                    user.UpdateBalance(amount + user.Balance);
                    queryString.Add("balance", "" + amount);
                    break;
                case "game":
                    if (BuyGift.Checked)
                    {
                        var code = GameCode.GenerateCode(game.Id);
                        var codeEncoded = EncodingHelper.Base64Encode(code.Code);
                        queryString.Add("code", HttpUtility.UrlEncode(codeEncoded));
                        
                    }
                    else
                    {
                        UserGame.AddGame(user.Id, game.Id, amount);
                        queryString.Add("game", "" + game.Id);
                    }

                    break;
            }


            Response.Redirect(paymentSuccessPage + "?" + queryString);
        }

        protected void UseBalance_OnCheckedChanged(object sender, EventArgs e)
        {
            payment.Visible = !UseBalance.Checked;
        }
    }
}