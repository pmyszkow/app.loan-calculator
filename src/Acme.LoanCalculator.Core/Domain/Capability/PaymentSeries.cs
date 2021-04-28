using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class PaymentSeries : IEquatable<PaymentSeries>
    {
        public PaymentSeries(IList<Payment> payments)
        {
            if (payments == null) throw new ArgumentNullException(nameof(payments));
            if (payments.Count == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(payments));

            Payments = new ReadOnlyCollection<Payment>(payments);
        }
        public IReadOnlyCollection<Payment> Payments { get; }

        public NaturalQuantity PaymentsCount => new NaturalQuantity(Payments.Count);

        public Currency PaymentCurrency => Payments.First().Total.Currency;

        public Money TotalInterest => Payments.Aggregate(new Money(0m, PaymentCurrency), (current, payment) => current + payment.Interest);

        public bool Equals(PaymentSeries other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Payments, other.Payments);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is PaymentSeries other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (Payments != null ? Payments.GetHashCode() : 0);
        }

        public static bool operator ==(PaymentSeries left, PaymentSeries right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PaymentSeries left, PaymentSeries right)
        {
            return !Equals(left, right);
        }
    }
}