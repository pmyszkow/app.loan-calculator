using System;
using System.Collections.Generic;
using System.Linq;
using Acme.LoanCalculator.Core.Domain.Generic;

namespace Acme.LoanCalculator.Core.Domain.Core
{
    public sealed class PaymentSeries : IEquatable<PaymentSeries>
    {
        public PaymentSeries(IReadOnlyList<Payment> payments, Money totalInterest)
        {
            PaymentsList = payments ?? throw new ArgumentNullException(nameof(payments));
            TotalInterest = totalInterest ?? throw new ArgumentNullException(nameof(totalInterest));
        }

        public IReadOnlyList<Payment> PaymentsList { get; }

        public Money TotalInterest { get; }

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
            return Equals(PaymentsList, other.PaymentsList) && Equals(TotalInterest, other.TotalInterest);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is PaymentSeries other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PaymentsList, TotalInterest);
        }
    }
}