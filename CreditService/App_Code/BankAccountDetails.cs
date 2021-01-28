using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CreditService
{
    public class BankAccountDto
    {
        public int identificationNumber { get; set; }
        public string holderName { get; set; }
        public double Balance { get; set; } = 0;

        public virtual List<CreditCardDto> CreditCards { get; set; }
    }

    public class BankAccountDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int identificationNumber { get; set; }
        public string holderName { get; set; }
        public double Balance { get; set; } = 0;

        public virtual List<CreditCardDetails> CreditCards { get; set; }
    }
}