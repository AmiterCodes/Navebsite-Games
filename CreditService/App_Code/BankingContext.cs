using System.Data.Entity;

namespace CreditService
{
    public class BankingContext : DbContext
    {
        public DbSet<BankAccountDetails> BankAccounts { get; set; }
        public DbSet<CreditCardDetails> CreditCards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public BankingContext()
        {
        }

    }
}