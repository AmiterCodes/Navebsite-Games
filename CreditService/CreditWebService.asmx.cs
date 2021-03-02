using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Linq;
using AutoMapper;
using Remotion.Linq.Clauses;

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
        private Mapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<BankAccountDetails, BankAccountDto>().ReverseMap();
            cfg.CreateMap<CreditCardDetails, CreditCardDto>().ReverseMap();
            cfg.CreateMap<Transaction, TransactionDto>().ReverseMap();


        }));

        /// <summary>
        /// Checks if a credit card is valid
        /// </summary>
        /// <param name="details">credit card details</param>
        /// <returns>True if valid</returns>
        [WebMethod]
        public bool IsValid(CreditCardDto details)
        {
            return mapper.Map<CreditCardDetails>(details).IsValid();
        }

        /// <summary>
        /// Pays a credit card to a bank account
        /// </summary>
        /// <param name="from">Credit card that pays</param>
        /// <param name="to">bank account that receives the payment</param>
        /// <param name="amountDollar">amount in dollars of transaction</param>
        /// <returns>TrasnactionDto object of the transaction</returns>
        [WebMethod]
        public TransactionDto Pay(CreditCardDto from, BankAccountDto to, double amountDollar)
        {
            if (!IsValid(from)) return null;
            var builder = new TransactionBuilder();
            Transaction transaction = builder
                .From(from.CardNumber)
                .To(to.identificationNumber)
                .AmountDollar(amountDollar)
                .TimeUtcNow()
                .Build();

            using (var db = new BankingContext())
            {
                Transaction saved = db.Transactions.Add(transaction);
                BankAccountDetails fromBank = db.bankAccounts.FirstOrDefault(bank => bank.CreditCards.Any(card => card.CardNumber == from.CardNumber));
                if (fromBank == null) return null;
                fromBank.Balance -= transaction.AmountDollar;
                BankAccountDetails toBank = db.bankAccounts.Find(to.identificationNumber);
                toBank.Balance += transaction.AmountDollar;

                db.SaveChanges();

                return mapper.Map<TransactionDto>(transaction);
            }
        }

        /// <summary>
        /// Gets the transaction history of a bank account
        /// </summary>
        /// <param name="bank">bank account to get information about</param>
        /// <returns>list of TransactionDto</returns>
        [WebMethod]
        public List<TransactionDto> TransactionHistoryOf(BankAccountDto bank)
        {
            using (var db = new BankingContext())
            {
                var query = from transaction in db.Transactions
                    where transaction.From.BankAccount.identificationNumber.Equals(bank.identificationNumber) || transaction.To.identificationNumber.Equals(bank.identificationNumber)
                    select transaction;

                return mapper.Map<List<TransactionDto>>(query.ToList());
            }
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
        
        private CreditCardDetails GenerateRandomVisaCreditCard(BankAccountDetails bank)
        {
            string prefix = VISA_PREFIX_LIST[random.Next(VISA_PREFIX_LIST.Length)];

            const int length = 16;

            return GenerateRandomCard(prefix, length, bank);
        }

        private CreditCardDetails GenerateRandomMastercardCreditCard(BankAccountDetails bank)
        {
            string prefix = MASTERCARD_PREFIX_LIST[random.Next(MASTERCARD_PREFIX_LIST.Length)];

            const int length = 16;

            return GenerateRandomCard(prefix, length, bank);
        }

        private CreditCardDetails GenerateRandomCard(string prefix, int length, BankAccountDetails bank)
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

            var date = DateTime.Now.AddYears(6).AddMonths(6);

            
            using (var db = new BankingContext())
            {
                var card = new CreditCardDetails
                {
                    BankAccountId= bank.identificationNumber,
                    CardNumber = ccnumber,
                    CardVerificationValue = (random.Next(1000) + "").PadLeft(3),
                    Month = date.Month,
                    Year = date.Year
                };

                db.creditCards.Add(card);
                db.SaveChanges();

                return card;
            }

        }


        /// <summary>
        /// Creates a new empty bank account
        /// </summary>
        /// <param name="name">account name</param>
        /// <param name="id">account id</param>
        /// <returns>new bank account's data as BankAccountDto</returns>
        [WebMethod]
        public BankAccountDto CreateEmptyBankAccount(string name, int id)
        {
            BankAccountDetails details = new BankAccountDetails
            {
                holderName = name,
                identificationNumber = id,
            };

            using (var db = new BankingContext())
            {
                db.bankAccounts.Add(details);
                db.SaveChanges();
            }
            
            return mapper.Map<BankAccountDto>(details);
        }

        /// <summary>
        /// Creates a bank account with a visa credit card
        /// </summary>
        /// <param name="name">bank </param>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebMethod]
        public BankAccountDto CreateVisaBankAccount(string name, int id)
        {
            var bank = CreateEmptyBankAccount(name, id);
            var card = AddNewVisaCard(bank);

            return new BankAccountDto
            {
                holderName = bank.holderName,
                Balance = bank.Balance,
                CreditCards = new List<CreditCardDto> {card},
                identificationNumber = bank.identificationNumber
            };
        }

        [WebMethod]
        public CreditCardDto AddNewMastercardCard(BankAccountDto bankAccount)
        {
            BankAccountDetails bank = mapper.Map<BankAccountDetails>(bankAccount);
            return mapper.Map<CreditCardDto>(GenerateRandomMastercardCreditCard(bank));
        }

        [WebMethod]
        public CreditCardDto AddNewVisaCard(BankAccountDto bankAccount)
        {
            BankAccountDetails bank = mapper.Map<BankAccountDetails>(bankAccount);
            return mapper.Map<CreditCardDto>(GenerateRandomVisaCreditCard(bank));
        }

        [WebMethod]
        public List<CreditCardDto> GetCardsForAccount(BankAccountDto bankAccount)
        {
            using (var db = new BankingContext())
            {
                var query = from card in db.creditCards
                    where card.BankAccount.Equals(bankAccount)
                    select card;

                return mapper.Map<List<CreditCardDto>>(query.ToList());
            }
        }

        [WebMethod]
        public List<BankAccountDto> GetAllBankAccounts()
        {
            using (var db = new BankingContext())
            {
                var query = from bank in db.bankAccounts
                    select bank;

                return mapper.Map<List<BankAccountDto>>(query.ToList());
            }
        }

        [WebMethod]
        public BankAccountDto GetBankAccount(int id)
        {
            using (var db = new BankingContext())
            {
                var query = from bank in db.bankAccounts
                    where bank.identificationNumber == id
                    select bank;

                return mapper.Map<BankAccountDto>(query.FirstOrDefault());
            }
        }

        [WebMethod]
        public List<TransactionDto> GetAllTransactions()
        {
            using (var db = new BankingContext())
            {
                var query = from transaction in db.Transactions
                    select transaction;

                return mapper.Map<List<TransactionDto>>(query.ToList());
            }
        }
    }
}
