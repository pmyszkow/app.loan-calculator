using System;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class AdministrationFeeTerms : IEquatable<AdministrationFeeTerms>
    {
        public AdministrationFeeTerms(Percent rate, Money maximumAdministrationFee)
        {
            Rate = rate ?? throw new ArgumentNullException(nameof(rate));
            MaximumAdministrationFee = maximumAdministrationFee ?? throw new ArgumentNullException(nameof(maximumAdministrationFee));
        }

        public Percent Rate { get; }

        public Money MaximumAdministrationFee { get; }

        public bool Equals(AdministrationFeeTerms other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Rate, other.Rate) && Equals(MaximumAdministrationFee, other.MaximumAdministrationFee);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is AdministrationFeeTerms other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Rate, MaximumAdministrationFee);
        }

        public static bool operator ==(AdministrationFeeTerms left, AdministrationFeeTerms right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AdministrationFeeTerms left, AdministrationFeeTerms right)
        {
            return !Equals(left, right);
        }
    }
}