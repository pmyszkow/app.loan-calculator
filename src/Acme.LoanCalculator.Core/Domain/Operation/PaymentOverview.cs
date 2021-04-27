using System;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Operation
{
    public sealed class PaymentOverview : IEquatable<PaymentOverview>
    {
        public PaymentOverview(Percent aop, Money totalInterest, Money totalAdministrativeFee)
        {
            AOP = aop ?? throw new ArgumentNullException(nameof(aop));
            TotalInterest = totalInterest ?? throw new ArgumentNullException(nameof(totalInterest));
            TotalAdministrativeFee = totalAdministrativeFee ?? throw new ArgumentNullException(nameof(totalAdministrativeFee));
        }

        public Percent AOP { get; }

        public Money TotalInterest { get; }

        public Money TotalAdministrativeFee { get; }

        public bool Equals(PaymentOverview other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(AOP, other.AOP) && Equals(TotalInterest, other.TotalInterest) && Equals(TotalAdministrativeFee, other.TotalAdministrativeFee);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is PaymentOverview other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AOP, TotalInterest, TotalAdministrativeFee);
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