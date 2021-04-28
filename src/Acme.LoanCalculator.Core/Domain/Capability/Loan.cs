using System;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class Loan : IEquatable<Loan>
    {
        public Loan(Money dueAmount, NaturalQuantity cyclesCount)
        {
            DueAmount = dueAmount ?? throw new ArgumentNullException(nameof(dueAmount));
            InstallmentsCount = cyclesCount ?? throw new ArgumentNullException(nameof(cyclesCount));
        }

        public Money DueAmount { get; }

        public NaturalQuantity InstallmentsCount { get; }

        public bool Equals(Loan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(DueAmount, other.DueAmount) && Equals(InstallmentsCount, other.InstallmentsCount);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Loan other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DueAmount, InstallmentsCount);
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