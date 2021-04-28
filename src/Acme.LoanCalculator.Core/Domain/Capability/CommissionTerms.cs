using System;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class CommissionTerms : IEquatable<CommissionTerms>
    {
        public CommissionTerms(Percent rate, Money maximumCommission)
        {
            Rate = rate ?? throw new ArgumentNullException(nameof(rate));
            MaximumCommission = maximumCommission ?? throw new ArgumentNullException(nameof(maximumCommission));
        }

        public Percent Rate { get; }

        public Money MaximumCommission { get; }

        public bool Equals(CommissionTerms other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Rate, other.Rate) && Equals(MaximumCommission, other.MaximumCommission);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is CommissionTerms other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Rate, MaximumCommission);
        }

        public static bool operator ==(CommissionTerms left, CommissionTerms right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CommissionTerms left, CommissionTerms right)
        {
            return !Equals(left, right);
        }
    }
}