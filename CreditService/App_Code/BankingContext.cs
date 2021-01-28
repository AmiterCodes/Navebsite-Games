using System.Data.Entity;

namespace CreditService
{
    public class BankingContext : DbContext
    {
        public DbSet<BankAccountDetails> bankAccounts { get; set; }
        public DbSet<CreditCardDetails> creditCards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public BankingContext()
        {
        }

    }
}