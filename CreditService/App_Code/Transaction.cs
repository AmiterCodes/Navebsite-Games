using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditService
{
    public class Transaction
    {
        public double AmountDollar { get; set; }
        public string CardHolder { get; set; }
        public string Receiver { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class TransactionBuilder
    {

        private readonly List<Action<Transaction>> _actions;

        public TransactionBuilder CardHolder(string name)
        {
            _actions.Add(t => t.CardHolder = name);
            return this;
        }

        public TransactionBuilder AmountDollar(double amount)
        {
            _actions.Add(t => t.AmountDollar = amount);
            return this;
        }

        public TransactionBuilder Receiver(string name)
        {
            _actions.Add(t => t.Receiver = name);
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