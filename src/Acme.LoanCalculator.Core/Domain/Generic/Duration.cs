using System;

namespace Acme.LoanCalculator.Core.Domain.Generic
{
    public sealed class Duration : IEquatable<Duration>
    {
        public Duration(int monthCount)
        {
            MonthCount = monthCount;
        }

        public static Duration Zero { get; } = new Duration(0);

        public int MonthCount { get; }

        public decimal GetYearCount() => MonthCount / 12m;

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
            return $"{MonthCount} monthCount";
        }

        public bool Equals(Duration other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return MonthCount == other.MonthCount;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Duration other && Equals(other);
        }

        public override int GetHashCode()
        {
            return MonthCount;
        }
    }
}