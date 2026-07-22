using EM.Planilla.Domain.Enums;
using EM.Planilla.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.Entities
{
    public class Loan : BaseEntity
    {
        public Money Amount { get; private set; }
        //public InterestRate InterestRate { get; private set; }
        public LoanTerm Term { get; private set; }
        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; }
        public LoanStatus Status { get; private set; }
        public string ReasonStatus { get; private set; }
        //public Money TotalInteres => InterestRate.CalculateInterest(Amount, Term.Months);
        //public Money TotalAmount => Amount + TotalInteres;
        public Loan()
        {

        }
        public Loan(Money amount, LoanTerm term, Employee employee)
        {
            if (amount == null) throw new ArgumentNullException(nameof(amount), "Amount cannot be null");
            //if (interestRate == null) throw new ArgumentNullException(nameof(interestRate), "InterestRate cannot be null");
            if (term == null) throw new ArgumentNullException(nameof(term), "Term cannot be null");

            Amount = amount;
            //InterestRate = interestRate;
            Term = term;
            EmployeeId = employee.Id;
            Status = LoanStatus.Pending;
            Employee = employee;
        }
        public static Loan Create(Money amount, LoanTerm term, Employee employee)
        {
            return new Loan(amount, term, employee);
        }
        public void Aprove()
        {
            if (Status != LoanStatus.Pending) throw new InvalidOperationException("Only pending loans can be approved.");
            Status = LoanStatus.Approved;
            UpdatedAt = DateTime.UtcNow;
        }
        public void Reject(string reason)
        {
            if (Status != LoanStatus.Pending) throw new InvalidOperationException("Only pending loans can be rejected.");
            if (string.IsNullOrEmpty(reason)) throw new ArgumentException("Reason for rejection cannot be null or empty", nameof(reason));
            Status = LoanStatus.Rejected;
            ReasonStatus = reason;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
