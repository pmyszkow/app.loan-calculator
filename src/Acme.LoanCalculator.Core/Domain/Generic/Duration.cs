using System;

namespace Acme.LoanCalculator.Core.Domain.Generic
{
    public sealed class Duration : IEquatable<Duration>
    {
        public Duration(int months)
        {
            Months = months;
        }

        public static Duration Zero { get; } = new Duration(0);

        public int Months { get; }

        public decimal GetYears() => Months / 12m;

        public static bool operator ==(Duration left, Duration right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Duration left, Duration right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{Months} months";
        }

        public bool Equals(Duration other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Months == other.Months;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Duration other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Months;
        }
    }
}