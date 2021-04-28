using System;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Operation
{
    public sealed class LoanCalculation : IEquatable<LoanCalculation>
    {
        public LoanCalculation(Money debt, Period duration, PaymentSeries payments, PaymentOverview paymentOverview)
        {
            Debt = debt ?? throw new ArgumentNullException(nameof(debt));
            Duration = duration ?? throw new ArgumentNullException(nameof(duration));
            Payments = payments ?? throw new ArgumentNullException(nameof(payments));
            PaymentOverview = paymentOverview ?? throw new ArgumentNullException(nameof(paymentOverview));
        }

        public Money Debt { get; }

        public Period Duration { get; }

        public PaymentSeries Payments { get; }

        public PaymentOverview PaymentOverview { get; }

        public bool Equals(LoanCalculation other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Debt, other.Debt) && Equals(Duration, other.Duration) && Equals(Payments, other.Payments) && Equals(PaymentOverview, other.PaymentOverview);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is LoanCalculation other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Debt, Duration, Payments, PaymentOverview);
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