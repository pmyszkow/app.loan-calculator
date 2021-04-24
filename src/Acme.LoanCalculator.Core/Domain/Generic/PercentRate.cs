using System;

namespace Acme.LoanCalculator.Core.Domain.Generic
{
    public sealed class PercentRate: IEquatable<PercentRate>
    {
        public PercentRate(decimal percents)
        {
            Percents = percents;
        }

        public Decimal Percents { get; }

        public Decimal DecimalRate => Percents / 100m;

        public static PercentRate operator *(PercentRate left, int right)
        {
            return new PercentRate(left.Percents * right);
        }

        public static PercentRate operator /(PercentRate left, int right)
        {
            return new PercentRate(left.Percents / right);
        }

        public static bool operator ==(PercentRate left, PercentRate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PercentRate left, PercentRate right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{Percents:F} %";
        }

        public bool Equals(PercentRate other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Percents == other.Percents;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is PercentRate other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Percents.GetHashCode();
        }
    }
}