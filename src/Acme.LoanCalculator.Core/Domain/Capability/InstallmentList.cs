using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class InstallmentList : IEquatable<InstallmentList>
    {
        public InstallmentList(IList<Installment> installments)
        {
            if (installments == null) throw new ArgumentNullException(nameof(installments));
            if (installments.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(installments));

            Installments = new ReadOnlyCollection<Installment>(installments);
        }
        public IReadOnlyCollection<Installment> Installments { get; }

        public NaturalQuantity InstallmentsCount => new NaturalQuantity(Installments.Count);

        public Currency InstallmentCurrency => Installments.First().TotalAmount.Currency;

        public Money InstallmentTotalAmount => Installments.First().TotalAmount;

        public Money TotalInterestAmount => Installments.Aggregate(new Money(0m, InstallmentCurrency), (current, installment) => current + installment.InterestPart);

        public bool Equals(InstallmentList other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Installments, other.Installments);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is InstallmentList other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (Installments != null ? Installments.GetHashCode() : 0);
        }

        public static bool operator ==(InstallmentList left, InstallmentList right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(InstallmentList left, InstallmentList right)
        {
            return !Equals(left, right);
        }
    }
}