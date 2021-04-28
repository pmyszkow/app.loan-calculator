using System;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class LoanSimulation : IEquatable<LoanSimulation>
    {
        public LoanSimulation(Money dueAmount, NaturalQuantity installmentsCount, InstallmentList installmentPlan)
        {
            DueAmount = dueAmount ?? throw new ArgumentNullException(nameof(dueAmount));
            InstallmentsCount = installmentsCount ?? throw new ArgumentNullException(nameof(installmentsCount));
            InstallmentPlan = installmentPlan ?? throw new ArgumentNullException(nameof(installmentPlan));
        }

        public Money DueAmount { get; }

        public NaturalQuantity InstallmentsCount { get; }

        public InstallmentList InstallmentPlan { get; }

        public bool Equals(LoanSimulation other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(DueAmount, other.DueAmount) && Equals(InstallmentsCount, other.InstallmentsCount) && Equals(InstallmentPlan, other.InstallmentPlan);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is LoanSimulation other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DueAmount, InstallmentsCount, InstallmentPlan);
        }

        public static bool operator ==(LoanSimulation left, LoanSimulation right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LoanSimulation left, LoanSimulation right)
        {
            return !Equals(left, right);
        }
    }
}