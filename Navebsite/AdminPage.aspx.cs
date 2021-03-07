using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Navebsite.Controls;
using Navebsite.CreditWebService;
using NavebsiteBL;

namespace Navebsite
{
    public partial class AdminPage : System.Web.UI.Page
    {
        private BankAccountDto bankAccount;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            sales.Sales = Sales.AllStats();
            gameList.Games = Game.ReviewGames();
            gameList.AddButtons = true;


            var service = new CreditWebService.CreditWebService();
            bankAccount = service.GetBankAccount(3);
            TransactionHistory.DataSource = service.TransactionHistoryOf(bankAccount);
            TransactionHistory.DataBind();

            List<CreditCardDto> cards = service.GetCardsForAccount(3).ToList();

            CreditCardRepeater.DataSource = cards;
            CreditCardRepeater.DataBind();
        }

        protected void CreditCardRepeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item;
            if (!(item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)) return;
            var cardDetails = (CreditCardDto)item.DataItem;

            ((Label) item.FindControl("svgnumber")).Text = cardDetails.CardNumber;
            ((Label)item.FindControl("svgname")).Text = bankAccount.HolderName;

            string month = cardDetails.Month + "";
            string year = cardDetails.Year.ToString().Substring(2, 2);
            if (month.Length == 1) month = "0" + month;

            ((Label)item.FindControl("svgexpire")).Text = month + "/" + year;
            ((Label)item.FindControl("svgsecurity")).Text = cardDetails.CardVerificationValue;

        }

        protected void OnClick(object sender, EventArgs e)
        {

            var service = new CreditWebService.CreditWebService();
            service.AddNewVisaCard(bankAccount);

            List<CreditCardDto> cards = service.GetCardsForAccount(3).ToList();

            CreditCardRepeater.DataSource = cards;
            CreditCardRepeater.DataBind();
        }
    }
}