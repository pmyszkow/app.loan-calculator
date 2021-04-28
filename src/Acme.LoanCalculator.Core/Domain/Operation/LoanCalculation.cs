using System;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Operation
{
    public sealed class LoanCalculation : IEquatable<LoanCalculation>
    {
        public LoanCalculation(Loan debt, PaymentSeries paymentsPlan)
        {
            this.Debt = debt ?? throw new ArgumentNullException(nameof(debt));
            this.PaymentsPlan = paymentsPlan ?? throw new ArgumentNullException(nameof(paymentsPlan));
        }

        public Loan Debt { get; }

        public PaymentSeries  PaymentsPlan { get; }

        public bool Equals(LoanCalculation other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Debt, other.Debt) && Equals(PaymentsPlan, other.PaymentsPlan);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is LoanCalculation other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Debt, PaymentsPlan);
        }

        public static bool operator ==(LoanCalculation left, LoanCalculation right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LoanCalculation left, LoanCalculation right)
        {
            return !Equals(left, right);
        }
    }
}