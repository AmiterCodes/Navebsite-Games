using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CreditService
{
    public class CreditCardDto
    {
        public string CardNumber { get; set; } // credit card number
        public string CardVerificationValue { get; set; } // 3 digits on the back
        public int Month { get; set; } // in number, january = 01, february 02 and so on
        public int Year { get; set; } // year, in the format 2020
        
        public int BankAccountId { get; set; }
    }

    public class CreditCardDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CardNumber { get; set; } // credit card number
        public string CardVerificationValue { get; set; } // 3 digits on the back
        public int Month { get; set; } // in number, january = 01, february 02 and so on
        public int Year { get; set; } // year, in the format 2020

        public int BankAccountId { get; set; }
        public BankAccountDetails BankAccount { get; set; }

        public override bool Equals(object other)
        {
            if (!(other is CreditCardDetails)) return false;

            CreditCardDetails card = (CreditCardDetails) other;
             return card.Month == this.Month
                   && card.Year == this.Year
                   && card.CardNumber == this.CardNumber
                   && card.CardVerificationValue == this.CardVerificationValue;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool IsValid()
        {
            var len = CardNumber.Length;

            if (len == 0) return false;
            

            // check for all numbers
            if (!CardNumber.All(char.IsDigit)) return false;
            if (!CardVerificationValue.All(char.IsDigit)) return false;

            if (CardVerificationValue.Length != 3) return false;



            // Check card not expired

            if (Month > 12) return false;

            var time = DateTime.Now;
            if (time.Year > Year) return false;
            if (time.Year == Year && time.Month > Month) return false;


            using (var db = new BankSystemContext())
            {
                var query = from card in db.CreditCards
                    where card.Month == this.Month
                          && card.Year == this.Year
                          && card.CardNumber == this.CardNumber
                          && card.CardVerificationValue == this.CardVerificationValue
                select card.BankAccount;

                BankAccountDetails found = query.FirstOrDefault();

                this.BankAccount = found;

                return found != null;

            }
        }
    }
}