using System;
using System.Collections.Generic;
using System.Linq;
using Acme.LoanCalculator.Core.Domain.Generic;

namespace Acme.LoanCalculator.Core.Domain.Core
{
    public sealed class Annuity : IEquatable<Annuity>
    {
        public Annuity(IReadOnlyList<Payment> payments)
        {
            PaymentsList = payments ?? throw new ArgumentNullException(nameof(payments));
        }

        public IReadOnlyList<Payment> PaymentsList { get; }

        public Money GetTotalInterest()
        {
            return PaymentsList.Aggregate(Money.Zero, (current, payment) => current + payment.Interest);
        }

        public static bool operator ==(Annuity left, Annuity right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Annuity left, Annuity right)
        {
            return !Equals(left, right);
        }

        public bool Equals(Annuity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.PaymentsList.SequenceEqual(PaymentsList);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Annuity other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (PaymentsList != null ? PaymentsList.GetHashCode() : 0);
        }
    }
}