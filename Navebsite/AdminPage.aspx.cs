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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            sales.Sales = Sales.AllStats();
            gameList.Games = Game.ReviewGames();
            gameList.AddButtons = true;


            var service = new CreditWebService.CreditWebService();
            BankAccountDto bank = service.GetBankAccount(3);
            TransactionHistory.DataSource = service.TransactionHistoryOf(bank);
            TransactionHistory.DataBind();
        }
    }
}