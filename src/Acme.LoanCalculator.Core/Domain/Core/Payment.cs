using System;
using Acme.LoanCalculator.Core.Domain.Generic;

namespace Acme.LoanCalculator.Core.Domain.Core
{
    public sealed class Payment : IEquatable<Payment>
    {
        public Payment(Money instalment, Money interest)
        {
            Money.AssertIsCurrencyTheSame(instalment,interest);
            Instalment = instalment ?? throw new ArgumentNullException(nameof(instalment));
            Interest = interest ?? throw new ArgumentNullException(nameof(interest));
        }

        public static Payment FromTotalAndInterest(Money total, Money interest)
        {
            if (total == null) throw new ArgumentNullException(nameof(total));
            if (interest == null) throw new ArgumentNullException(nameof(interest));

            return new Payment(total - interest, interest);
        }

        public Money Instalment { get; }

        public Money Interest { get; }

        public Money Total => Instalment + Interest;

        public static bool operator ==(Payment left, Payment right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Payment left, Payment right)
        {
            return !Equals(left, right);
        }

        public bool Equals(Payment other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Instalment, other.Instalment) && Equals(Interest, other.Interest);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Payment other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Instalment, Interest);
        }

        public override string ToString()
        {
            return $"{nameof(Payment)} - {nameof(Instalment)}: {Instalment}, {nameof(Interest)}: {Interest}, {nameof(Total)}: {Total}";
        }
    }
}