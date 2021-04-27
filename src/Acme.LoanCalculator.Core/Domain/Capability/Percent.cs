using System;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class Percent: IEquatable<Percent>
    {
        public Percent(decimal value)
        {
            if (value < 0) throw new ArgumentException("Percent value must be positive.", nameof(value));
            Value = value;
        }

        public static Percent FromDecimalFraction(decimal fraction) => new Percent(fraction * 100);

        public static Percent Zero { get; } = new Percent(0m);

        public decimal Value { get; }

        public decimal DecimalFraction => Value / 100m;

        public static Percent operator *(Percent left, decimal right)
        {
            return new Percent(left.Value * right);
        }

        public static Percent operator /(Percent left, decimal right)
        {
            return new Percent(left.Value / right);
        }

        public static bool operator ==(Percent left, Percent right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Percent left, Percent right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{Value:F} %";
        }

        public bool Equals(Percent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Percent other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}