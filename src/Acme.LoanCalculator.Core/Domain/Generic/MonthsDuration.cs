using System;

namespace Acme.LoanCalculator.Core.Domain.Generic
{
    public sealed class MonthsDuration : IEquatable<MonthsDuration>
    {
        public MonthsDuration(int months)
        {
            Months = months;
        }

        public static MonthsDuration FromYears(int years) => new MonthsDuration(years * 12);

        public static MonthsDuration Zero { get; } = new MonthsDuration(0);

        public int Months { get; }

        public int Years => Months / 12;

        public static bool operator ==(MonthsDuration left, MonthsDuration right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MonthsDuration left, MonthsDuration right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{Months} months";
        }

        public bool Equals(MonthsDuration other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Months == other.Months;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is MonthsDuration other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Months;
        }
    }
}