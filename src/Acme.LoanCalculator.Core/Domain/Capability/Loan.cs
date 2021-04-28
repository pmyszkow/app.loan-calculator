using System;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class Loan : IEquatable<Loan>
    {
        public Loan(Money amount, NaturalQuantity cyclesCount)
        {
            Amount = amount ?? throw new ArgumentNullException(nameof(amount));
            CyclesCount = cyclesCount ?? throw new ArgumentNullException(nameof(cyclesCount));
        }

        public Money Amount { get; }

        public NaturalQuantity CyclesCount { get; }

        public bool Equals(Loan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Amount, other.Amount) && Equals(CyclesCount, other.CyclesCount);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Loan other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, CyclesCount);
        }

        public static bool operator ==(Loan left, Loan right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Loan left, Loan right)
        {
            return !Equals(left, right);
        }
    }
}