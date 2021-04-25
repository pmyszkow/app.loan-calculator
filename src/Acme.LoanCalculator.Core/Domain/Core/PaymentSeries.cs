using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Acme.LoanCalculator.Core.Domain.Generic;

namespace Acme.LoanCalculator.Core.Domain.Core
{
    public sealed class PaymentSeries : IEquatable<PaymentSeries>
    {
        public PaymentSeries(IList<Payment> payments)
        {
            Elements = new ReadOnlyCollection<Payment>(payments);
        }

        public IReadOnlyCollection<Payment> Elements { get; }
        
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
            return Elements.SequenceEqual(other.Elements);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is PaymentSeries other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (Elements != null ? Elements.GetHashCode() : 0);
        }
    }
}