using System;

namespace Acme.LoanCalculator.Core.Domain.Generic
{
    public sealed class AnnualInterestRate : IEquatable<AnnualInterestRate>
    {
        public AnnualInterestRate(Percent percentage)
        {
            Percentage = percentage;
        }

        public static AnnualInterestRate Zero { get; } = new AnnualInterestRate(Percent.Zero);

        public Percent Percentage { get; }

        public Percent GetMonthlyPercentage() => Percentage / 12m;

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
            return Equals(Percentage, other.Percentage);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is AnnualInterestRate other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (Percentage != null ? Percentage.GetHashCode() : 0);
        }
    }
}