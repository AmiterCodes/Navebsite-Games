using System;
using System.Linq;

namespace CreditService
{
    public class CreditCardDetails
    {
        public string HolderName { get; set; } // name of credit card holder, e.g "AMIT NAVE"
        public string CardNumber { get; set; } // credit card number
        public string CardVerificationValue { get; set; } // 3 digits on the back
        public int Month { get; set; } // in number, january = 01, february 02 and so on
        public int Year { get; set; } // year, in the format 2020

        private static bool LuhnAlgorithm(string digits)
        {
            return digits.All(char.IsDigit) && digits.Reverse()
                .Select(c => c - 48)
                .Select((thisNum, i) => i % 2 == 0
                    ? thisNum
                    : (thisNum *= 2) > 9
                        ? thisNum - 9
                        : thisNum
                ).Sum() % 10 == 0;
        }

        public bool IsValid()
        {
            var len = CardNumber.Length;

            if (len == 0) return false;

            // check for all numbers
            if (!CardNumber.All(char.IsDigit)) return false;
            if (!CardVerificationValue.All(char.IsDigit)) return false;

            if (CardVerificationValue.Length != 3) return false;


            // check for network validity
            switch (CardNumber[0])
            {
                case '4':
                    // Visa
                    if (len != 13 && len != 16) return false;
                    break;
                case '5':
                    // Mastercard
                    if (len != 16) return false;
                    break;
                case '3':
                    switch (len)
                    {
                        // Diner's Club & Carte Blanche
                        case 14:
                        {
                            if (CardNumber[1] != '0' && CardNumber[1] != '6' && CardNumber[1] != '8') return false;
                            break;
                        }
                        // American Express
                        case 15:
                        {
                            if (CardNumber[1] != '4' && CardNumber[1] != '7') return false;
                            break;
                        }
                        default:
                            return false;
                    }

                    break;
                case '6':
                    // Discover
                    if (len != 16) return false;
                    break;


                default:
                    return false;
            }


            // Check card not expired

            if (Month > 12) return false;

            var time = DateTime.Now;
            if (time.Year % 100 > Year) return false;
            if (time.Year % 100 == Year && time.Month > Month) return false;
            return LuhnAlgorithm(CardNumber);
        }
    }
}