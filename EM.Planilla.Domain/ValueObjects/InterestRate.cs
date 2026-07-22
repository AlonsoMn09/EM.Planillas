using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.ValueObjects
{
    public class InterestRate
    {
        public decimal Value { get; set; }
        public decimal AsPercentage => Value * 100;
        private InterestRate()
        {
            
        }
        private InterestRate(decimal value)
        {
            if (value < 1) throw new ArgumentException("Interest rate must be greater than or equals to 1", nameof(value));
            Value = value;            
        }
        public static InterestRate Create(decimal value)
        {
            return new InterestRate(value);
        }
        public Money CalculateInterest(Money amount, int months)
        {
            if(months < 0) throw new ArgumentException("Months must be greater than or equals to 0", nameof(months));
            decimal interestAmount = amount.Amount * Value * months / 12;
            return Money.Create(amount.Currency, interestAmount);
        }
    }
}
