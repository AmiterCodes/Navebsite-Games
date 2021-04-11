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

    /// <summary>
    /// Represents a transaction
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// id of transaction
        /// </summary>
        public int TransactionId { get; set; }
        
        /// <summary>
        /// dollar amount that was passed in transaction
        /// </summary>
        public double AmountDollar { get; set; }

        /// <summary>
        /// number of transaction card
        /// </summary>
        public string CardNumber { get; set; }
        /// <summary>
        /// credit card that the transaction is from
        /// </summary>
        public virtual CreditCardDetails From { get; set; }

        /// <summary>
        /// id of bank account that the transaction is to
        /// </summary>
        public int ToId { get; set; }
        /// <summary>
        /// bank account details of the bank account that the transaction is sent to
        /// </summary>
        public virtual BankAccountDetails To { get; set; }
        /// <summary>
        /// timestamp of transaction
        /// </summary>
        public DateTime Timestamp { get; set; }
    }

    /// <summary>
    /// builder class for a transaction
    /// </summary>
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
            _actions.Add(t => t.ToId = id);
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