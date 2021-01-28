using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CreditService
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }

        public double AmountDollar { get; set; }
        
        public virtual CreditCardDto From { get; set; }
        
        public virtual BankAccountDto To { get; set; }
        public DateTime Timestamp { get; set; }
    }


    public class Transaction
    {
        public int TransactionId { get; set; }

        public double AmountDollar { get; set; }

        public string CardNumber { get; set; }
        public virtual CreditCardDetails From { get; set; }

        public int identificationNumber { get; set; }
        public virtual BankAccountDetails To { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class TransactionBuilder
    {

        private readonly List<Action<Transaction>> _actions;

        public TransactionBuilder From(string cardNumber)
        {
            _actions.Add(t => t.CardNumber = cardNumber);
            return this;
        }

        public TransactionBuilder AmountDollar(double amount)
        {
            _actions.Add(t => t.AmountDollar = amount);
            return this;
        }

        public TransactionBuilder To(int id)
        {
            _actions.Add(t => t.identificationNumber = id);
            return this;
        }

        public TransactionBuilder TimeUtcNow()
        {
            _actions.Add(t => t.Timestamp = DateTime.UtcNow);
            return this;
        }

        public TransactionBuilder()
        {
            this._actions = new List<Action<Transaction>>();
        }

        public Transaction Build()
        {
            Transaction transaction = new Transaction();
            _actions.ForEach(a => a(transaction));
            return transaction;
        }
    }

}