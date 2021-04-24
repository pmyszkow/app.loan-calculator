using System;
using Acme.LoanCalculator.Core.Domain.Generic;

namespace Acme.LoanCalculator.Core.Domain.Core
{
    public sealed class LoanSpecification : IEquatable<LoanSpecification>
    {
        public LoanSpecification(Money amount, MonthsDuration duration, Money commission, AnnualInterestRate interestRate)
        {
            Amount = amount ?? throw new ArgumentNullException(nameof(amount));
            Duration = duration ?? throw new ArgumentNullException(nameof(duration));
            Commission = commission ?? throw new ArgumentNullException(nameof(commission));
            InterestRate = interestRate ?? throw new ArgumentNullException(nameof(interestRate));
        }

        public Money Amount { get; }

        public MonthsDuration Duration { get; }
        
        public Money Commission { get; }

        public AnnualInterestRate InterestRate { get; }

        public static bool operator ==(LoanSpecification left, LoanSpecification right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LoanSpecification left, LoanSpecification right)
        {
            return !Equals(left, right);
        }

        public bool Equals(LoanSpecification other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Amount, other.Amount) && Equals(Duration, other.Duration) && Equals(Commission, other.Commission) && Equals(InterestRate, other.InterestRate);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is LoanSpecification other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Duration, Commission, InterestRate);
        }
    }
}