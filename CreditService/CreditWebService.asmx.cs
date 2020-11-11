using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Linq;

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

        public static string[] VISA_PREFIX_LIST = new[]
        {
            "4539",
            "4556", "4916", "4532", "4929", "40240071", "4485", "4716", "4"
        };

        public static string[] MASTERCARD_PREFIX_LIST = new[]
                                                            {
                                                                "51",
                                                                "52", "53", "54", "55",
                                                                "2221",
                                                                "2222",
                                                                "2223",
                                                                "2224",
                                                                "2225",
                                                                "2226",
                                                                "2227",
                                                                "2228",
                                                                "2229",
                                                                "223",
                                                                "224",
                                                                "225",
                                                                "226",
                                                                "227",
                                                                "228",
                                                                "229",
                                                                "23",
                                                                "24",
                                                                "25",
                                                                "26",
                                                                "270",
                                                                "271",
                                                                "2720"
                                                            };

        private Random random = new Random();

        private string GenerateRandomVisaCreditCard()
        {
            string prefix = VISA_PREFIX_LIST[random.Next(VISA_PREFIX_LIST.Length)];

            const int length = 16;

            return GenerateRandomCard(prefix, length);
        }

        private string GenerateRandomMastercardCreditCard()
        {
            string prefix = MASTERCARD_PREFIX_LIST[random.Next(MASTERCARD_PREFIX_LIST.Length)];

            const int length = 16;

            return GenerateRandomCard(prefix, length);
        }

        private string GenerateRandomCard(string prefix, int length)
        {
            string ccnumber = prefix;
            while (ccnumber.Length < (length - 1))
            {
                double rnd = (random.NextDouble() * 1.0f - 0f);

                ccnumber += Math.Floor(rnd * 10);
            }


            // reverse number and convert to int
            var reversedCCnumberstring = ccnumber.ToCharArray().Reverse();

            var reversedCCnumberList = reversedCCnumberstring.Select(c => Convert.ToInt32(c.ToString()));

            // calculate sum //Luhn Algorithm 
            int sum = 0;
            int pos = 0;
            int[] reversedCCnumber = reversedCCnumberList.ToArray();

            while (pos < length - 1)
            {
                int odd = reversedCCnumber[pos] * 2;

                if (odd > 9)
                    odd -= 9;

                sum += odd;

                if (pos != (length - 2))
                    sum += reversedCCnumber[pos + 1];

                pos += 2;
            }

            // calculate check digit
            int checkdigit =
                Convert.ToInt32((Math.Floor((decimal) sum / 10) + 1) * 10 - sum) % 10;

            ccnumber += checkdigit;

            return ccnumber;
        }

        [WebMethod]
        public CreditCardDetails CreateMastercardAccount(string name)
        {
            var date = DateTime.Now.AddYears(6).AddMonths(6);

            var credit = new CreditCardDetails
            {
                CardNumber = GenerateRandomMastercardCreditCard(),
                CardVerificationValue = "" + (100 + random.Next(900)),
                HolderName = name,
                Month = date.Month,
                Year = date.Year
            };

            return credit;
        }

        [WebMethod]
        public CreditCardDetails CreateVisaAccount(string name)
        {
            var date = DateTime.Now.AddYears(6).AddMonths(6);

            var credit = new CreditCardDetails
            {
                CardNumber = GenerateRandomVisaCreditCard(),
                CardVerificationValue = "" + (100 + random.Next(900)),
                HolderName = name,
                Month = date.Month,
                Year = date.Year
            };

            return credit;
        }
    }
}
