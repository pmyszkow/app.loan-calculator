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
            Series = new ReadOnlyCollection<Payment>(payments);
        }

        public IReadOnlyCollection<Payment> Series { get; }

        public Money TotalInterest
        {
            get
            {
                return Series.Aggregate(Money.Zero, (current, payment) => current + payment.Interest);
            }
        }

        public static bool operator ==(PaymentSeries left, PaymentSeries right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PaymentSeries left, PaymentSeries right)
        {
            return !Equals(left, right);
        }

        public bool Equals(PaymentSeries other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Series.SequenceEqual(other.Series);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is PaymentSeries other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (Series != null ? Series.GetHashCode() : 0);
        }
    }
}