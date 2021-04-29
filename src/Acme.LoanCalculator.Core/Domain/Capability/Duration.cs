using System;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class Duration : IEquatable<Duration>
    {
        public Duration(NaturalQuantity years, NaturalQuantity months)
        {
            Years = years ?? throw new ArgumentNullException(nameof(years));
            Months = months ?? throw new ArgumentNullException(nameof(months));
        }

        public static Duration FromYears(double years)
        {
            var totalMonthsCount = Convert.ToInt32(years * 12d);

            var yearsCount = totalMonthsCount / 12;
            var monthsCount = totalMonthsCount % 12;

            return new Duration(new NaturalQuantity(yearsCount), new NaturalQuantity(monthsCount));
        }

        public NaturalQuantity Years { get; }

        public NaturalQuantity Months { get; }

        public NaturalQuantity TotalMonths => Years * 12 + Months;

        public NaturalQuantity TotalYears => Years;

        public bool Equals(Duration other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Years, other.Years) && Equals(Months, other.Months);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Duration other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Years, Months);
        }

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
            return $"{Years} {nameof(Years)} and {Months} {nameof(Months)}";
        }
    }
}