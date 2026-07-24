using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.ValueObjects
{
    public class Money
    {
        public string? Currency { get; init; }
        public decimal Amount { get; set; }
        private Money()
        {
            
        }
        private Money(string currency, decimal amount)
        {
            if (string.IsNullOrEmpty(currency)) throw new ArgumentException("Currency cannot be null or empty", nameof(currency));
            if (amount < 0) throw new ArgumentException("Amount must be greater than zero", nameof(amount));
            Currency = currency;
            Amount = amount;
        }
        public static Money Create(string currency, decimal amount)
        {
            return new Money(currency, amount);
        }
        public static Money operator +(Money a, Money b)
        {
            if (a.Currency != b.Currency) throw new InvalidOperationException("Cannot add amounts with different currencies");
            return new Money(a.Currency, a.Amount + b.Amount);
        }
        public static Money operator -(Money a, Money b)
        {
            if (a.Currency != b.Currency) throw new InvalidOperationException("Cannot subtract amounts with different currencies");
            return new Money(a.Currency, a.Amount - b.Amount);
        }
    }
}
