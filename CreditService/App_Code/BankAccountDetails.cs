using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditService
{
    public class BankAccountDto
    {
        public int Id { get; set; }
        public string HolderName { get; set; }
        public double Balance { get; set; } = 0;

        public virtual List<CreditCardDto> CreditCards { get; set; }
    }

    public class BankAccountDetails
    {
        [Key]
        public int Id { get; set; }
        public string HolderName { get; set; }
        public double Balance { get; set; } = 0;
        public virtual List<CreditCardDetails> CreditCards { get; set; }
    }
}