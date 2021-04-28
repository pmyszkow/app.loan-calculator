using System;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Operation
{
    public sealed class LoanSimulation : IEquatable<LoanSimulation>
    {
        public LoanSimulation(Loan debt, PaymentSeries paymentsPlan)
        {
            this.Debt = debt ?? throw new ArgumentNullException(nameof(debt));
            this.PaymentsPlan = paymentsPlan ?? throw new ArgumentNullException(nameof(paymentsPlan));
        }

        public Loan Debt { get; }

        public PaymentSeries  PaymentsPlan { get; }

        public bool Equals(LoanSimulation other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Debt, other.Debt) && Equals(PaymentsPlan, other.PaymentsPlan);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is LoanSimulation other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Debt, PaymentsPlan);
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