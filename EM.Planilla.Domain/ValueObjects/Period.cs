using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.ValueObjects
{
    public class Period
    {
        public string Month { get; init; }
        public string Year { get; init; }
        private Period()
        {

        }
        private Period(string month, string year)
        {
            if (string.IsNullOrEmpty(month)) throw new ArgumentException("Month cannot be null or empty", nameof(month));
            if (string.IsNullOrEmpty(year)) throw new ArgumentException("Year cannot be null or empty", nameof(year));
            Month = month;
            Year = year;
        }
        public static Period Create(string month, string year)
        {
            return new Period(month, year);
        }
    }
}
