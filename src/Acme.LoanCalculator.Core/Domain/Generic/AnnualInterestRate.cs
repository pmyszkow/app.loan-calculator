using System;

namespace Acme.LoanCalculator.Core.Domain.Generic
{
    public sealed class AnnualInterestRate : IEquatable<AnnualInterestRate>
    {
        public AnnualInterestRate(Percent annual)
        {
            Annual = annual;
        }

        public static AnnualInterestRate Zero { get; } = new AnnualInterestRate(Percent.Zero);

        public Percent Annual { get; }

        public Percent Monthly => Annual / 12;

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
            return Equals(Annual, other.Annual);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is AnnualInterestRate other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (Annual != null ? Annual.GetHashCode() : 0);
        }
    }
}