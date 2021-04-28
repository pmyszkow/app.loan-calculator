using System;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class PaymentOverview : IEquatable<PaymentOverview>
    {
        public PaymentOverview(Percent aop, Money totalInterestAmount, Money totalAdministrativeFee)
        {
            Aop = aop ?? throw new ArgumentNullException(nameof(aop));
            TotalInterestAmount = totalInterestAmount ?? throw new ArgumentNullException(nameof(totalInterestAmount));
            TotalAdministrativeFee = totalAdministrativeFee ?? throw new ArgumentNullException(nameof(totalAdministrativeFee));
        }

        public Percent Aop { get; }

        public Money TotalInterestAmount { get; }

        public Money TotalAdministrativeFee { get; }

        public bool Equals(PaymentOverview other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Aop, other.Aop) && Equals(TotalInterestAmount, other.TotalInterestAmount) && Equals(TotalAdministrativeFee, other.TotalAdministrativeFee);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is PaymentOverview other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Aop, TotalInterestAmount, TotalAdministrativeFee);
        }

        public static bool operator ==(PaymentOverview left, PaymentOverview right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PaymentOverview left, PaymentOverview right)
        {
            return !Equals(left, right);
        }
    }
}