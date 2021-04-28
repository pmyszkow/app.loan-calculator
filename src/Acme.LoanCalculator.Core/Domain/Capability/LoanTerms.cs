using System;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class LoanTerms : IEquatable<LoanTerms>
    {
        public LoanTerms(Percent annualInterestRate, CycleInterval paymentInterval, Percent commissionRate, Money maximumCommission)
        {
            this.AnnualInterestRate = annualInterestRate ?? throw new ArgumentNullException(nameof(annualInterestRate));
            this.PaymentInterval = paymentInterval;
            this.CommissionRate = commissionRate ?? throw new ArgumentNullException(nameof(commissionRate));
            this.Maximumommission = maximumCommission ?? throw new ArgumentNullException(nameof(maximumCommission));
        }

        public Percent AnnualInterestRate { get; }

        public CycleInterval PaymentInterval { get; }

        public Percent CommissionRate { get; }

        public Money Maximumommission { get; }

        public bool Equals(LoanTerms other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(AnnualInterestRate, other.AnnualInterestRate) && PaymentInterval == other.PaymentInterval && Equals(CommissionRate, other.CommissionRate) && Equals(Maximumommission, other.Maximumommission);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is LoanTerms other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AnnualInterestRate, (int) PaymentInterval, CommissionRate, Maximumommission);
        }

        public static bool operator ==(LoanTerms left, LoanTerms right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LoanTerms left, LoanTerms right)
        {
            return !Equals(left, right);
        }
    }
}