using System;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class Loan : IEquatable<Loan>
    {
        public Loan(Money debt, Period duration)
        {
            Debt = debt ?? throw new ArgumentNullException(nameof(debt));
            Duration = duration ?? throw new ArgumentNullException(nameof(duration));
        }

        public Money Debt { get; }

        public Period Duration { get; }

        public bool Equals(Loan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Debt, other.Debt) && Equals(Duration, other.Duration);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Loan other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Debt, Duration);
        }

        public static bool operator ==(Loan left, Loan right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Loan left, Loan right)
        {
            return !Equals(left, right);
        }
    }
}