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
            Payments = new ReadOnlyCollection<Payment>(payments);
        }

        public IReadOnlyCollection<Payment> Payments { get; }
        
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
            return Payments.SequenceEqual(other.Payments);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is PaymentSeries other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (Payments != null ? Payments.GetHashCode() : 0);
        }
    }
}