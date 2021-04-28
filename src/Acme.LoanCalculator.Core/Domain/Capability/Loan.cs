using System;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class Loan : IEquatable<Loan>
    {
        public Loan(Money amount, NaturalQuantity cyclesCount)
        {
            DueAmount = amount ?? throw new ArgumentNullException(nameof(amount));
            CyclesCount = cyclesCount ?? throw new ArgumentNullException(nameof(cyclesCount));
        }

        public Money DueAmount { get; }

        public NaturalQuantity CyclesCount { get; }

        public bool Equals(Loan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(DueAmount, other.DueAmount) && Equals(CyclesCount, other.CyclesCount);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Loan other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DueAmount, CyclesCount);
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