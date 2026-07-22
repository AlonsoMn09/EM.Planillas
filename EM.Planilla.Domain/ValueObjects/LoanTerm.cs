using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.ValueObjects
{
    public class LoanTerm
    {
        public int Months { get; init; }
        private LoanTerm()
        {

        }
        private LoanTerm(int months)
        {
            if (months <= 0) throw new ArgumentException("Months must be greater than zero", nameof(months));
            if (months > 360) throw new ArgumentException("Months must be less than or equal to 360", nameof(months));
            Months = months;
        }
        public static LoanTerm Create(int months)
        {
            return new LoanTerm(months);
        }
        public (int Years, int MonthsRemainder) ToYearsAndMonths()
        {
            int years = Months / 12;
            int monthsRemainder = Months % 12;
            return (years, monthsRemainder);
        }
    }
}
