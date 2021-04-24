using System;

namespace Acme.LoanCalculator.Core.Domain.Generic
{
    public sealed class AnnualInterestRate : IEquatable<AnnualInterestRate>
    {
        public AnnualInterestRate(PercentRate annualRate)
        {
            AnnualRate = annualRate;
        }

        public static AnnualInterestRate Zero { get; } = new AnnualInterestRate(PercentRate.Zero);

        public PercentRate AnnualRate { get; }

        public PercentRate MonthlyRate => AnnualRate / 12;

        public static bool operator ==(AnnualInterestRate left, AnnualInterestRate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AnnualInterestRate left, AnnualInterestRate right)
        {
            return !Equals(left, right);
        }

        public bool Equals(AnnualInterestRate other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(AnnualRate, other.AnnualRate);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is AnnualInterestRate other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (AnnualRate != null ? AnnualRate.GetHashCode() : 0);
        }
    }
}