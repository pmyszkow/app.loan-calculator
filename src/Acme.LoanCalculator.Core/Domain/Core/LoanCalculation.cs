using System;
using Acme.LoanCalculator.Core.Domain.Generic;

namespace Acme.LoanCalculator.Core.Domain.Core
{
    public sealed class LoanCalculation : IEquatable<LoanCalculation>
    {
        public LoanCalculation(Money amount, Currency currency, MonthsDuration duration, Money commission, AnnualInterestRate interestRate, PaymentSeries payments, Percent aop)
        {
            Money.AssertIsCurrencyTheSame(amount ,commission);
            Amount = amount ?? throw new ArgumentNullException(nameof(amount));
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
            Duration = duration ?? throw new ArgumentNullException(nameof(duration));
            Commission = commission ?? throw new ArgumentNullException(nameof(commission));
            InterestRate = interestRate ?? throw new ArgumentNullException(nameof(interestRate));
            Payments = payments ?? throw new ArgumentNullException(nameof(payments));
            Aop = aop ?? throw new ArgumentNullException(nameof(aop));
        }

        public Money Amount { get; }

        public Currency Currency { get; }

        public Money Commission { get; }

        public MonthsDuration Duration { get; }

        public AnnualInterestRate InterestRate { get; }

        public PaymentSeries Payments { get; }

        public Percent Aop { get; }

        public bool Equals(LoanCalculation other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Amount, other.Amount) && Equals(Duration, other.Duration) && Equals(Commission, other.Commission) && Equals(InterestRate, other.InterestRate) && Equals(Aop, other.Aop) && Equals(Payments, other.Payments);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is LoanCalculation other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Duration, Commission, InterestRate, Aop, Payments);
        }

        public static bool operator ==(LoanCalculation left, LoanCalculation right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LoanCalculation left, LoanCalculation right)
        {
            return !Equals(left, right);
        }
    }
}