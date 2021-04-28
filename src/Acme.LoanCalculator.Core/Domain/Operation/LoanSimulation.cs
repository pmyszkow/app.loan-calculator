using System;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Operation
{
    public sealed class LoanSimulation : IEquatable<LoanSimulation>
    {
        public LoanSimulation(Money dueAmount, NaturalQuantity cyclesCount, PaymentSeries paymentPlan)
        {
            DueAmount = dueAmount ?? throw new ArgumentNullException(nameof(dueAmount));
            CyclesCount = cyclesCount ?? throw new ArgumentNullException(nameof(cyclesCount));
            PaymentPlan = paymentPlan ?? throw new ArgumentNullException(nameof(paymentPlan));
        }

        public Money DueAmount { get; }

        public NaturalQuantity CyclesCount { get; }

        public PaymentSeries PaymentPlan { get; }

        public bool Equals(LoanSimulation other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(DueAmount, other.DueAmount) && Equals(CyclesCount, other.CyclesCount) && Equals(PaymentPlan, other.PaymentPlan);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is LoanSimulation other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DueAmount, CyclesCount, PaymentPlan);
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