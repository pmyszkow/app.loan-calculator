using System;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class NaturalQuantity : IEquatable<NaturalQuantity>
    {
        public NaturalQuantity(int value)
        {
            if (value < 0) throw new ArgumentException("Natural quantity value must be positive.", nameof(value));
            Value = value;
        }

        public int Value { get; }

        public bool Equals(NaturalQuantity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is NaturalQuantity other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public static bool operator ==(NaturalQuantity left, NaturalQuantity right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(NaturalQuantity left, NaturalQuantity right)
        {
            return !Equals(left, right);
        }
    }
}