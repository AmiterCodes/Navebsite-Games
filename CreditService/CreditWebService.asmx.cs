using System;
using System.Collections.Generic;
using System.Web.Services;

namespace CreditService
{
    /// <summary>
    /// Summary description for CreditWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public partial class CreditWebService : WebService
    {


        [WebMethod]
        public bool IsValid(CreditCardDetails details)
        {
            return details.IsValid();
        }

        [WebMethod]
        public Transaction Pay(CreditCardDetails details, string to, double amountDollar)
        {
            if (!details.IsValid()) return null;
            var builder = new TransactionBuilder();
            return builder
                .CardHolder(details.HolderName)
                .Receiver(to)
                .AmountDollar(amountDollar)
                .TimeUtcNow()
                .Build();
        }

        [WebMethod]
        public List<Transaction> TransactionHistoryOf(int creditCard)
        {
            throw new NotImplementedException();
        }
    }
}
