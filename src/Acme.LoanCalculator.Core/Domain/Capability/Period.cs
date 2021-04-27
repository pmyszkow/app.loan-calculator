using System;
using System.ComponentModel;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class Period : IEquatable<Period>
    {
        public Period(int cycles, CycleInterval interval)
        {
            if (!Enum.IsDefined(typeof(CycleInterval), interval))
                throw new InvalidEnumArgumentException(nameof(interval), (int) interval, typeof(CycleInterval));
            Cycles = cycles;
            Interval = interval;
        }

        public int Cycles { get; }

        public CycleInterval Interval { get; }

        public int Months => Interval == CycleInterval.Year ? Cycles * 12 : Cycles;

        public decimal Years => Interval == CycleInterval.Month ? Cycles / 12m : Convert.ToDecimal(Cycles);

        public bool Equals(Period other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Cycles == other.Cycles && Interval == other.Interval;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Period other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Cycles, (int) Interval);
        }

        public static bool operator ==(Period left, Period right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Period left, Period right)
        {
            return !Equals(left, right);
        }
    }
}