using System;
using Acme.LoanCalculator.Core.Domain.Generic;

namespace Acme.LoanCalculator.Core.Domain.Core
{
    public sealed class Payment : IEquatable<Payment>
    {
        public Payment(int ordinal, Money installment, Money interest)
        {
            Money.AssertIsCurrencyTheSame(installment,interest);
            Ordinal = ordinal;
            Installment = installment ?? throw new ArgumentNullException(nameof(installment));
            Interest = interest ?? throw new ArgumentNullException(nameof(interest));
        }

        public static Payment FromChargeAndInterest(Money charge, Money interest, int ordinal)
        {
            if (charge == null) throw new ArgumentNullException(nameof(charge));
            if (interest == null) throw new ArgumentNullException(nameof(interest));

            return new Payment(ordinal, charge - interest, interest);
        }

        public int Ordinal { get; }

        public Money Installment { get; }

        public Money Interest { get; }

        public Money GetCharge() => Installment + Interest;

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
            return Ordinal == other.Ordinal && Equals(Installment, other.Installment) && Equals(Interest, other.Interest);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Payment other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Ordinal, Installment, Interest);
        }

        public override string ToString()
        {
            return $"{nameof(Payment)} no. {Ordinal}, {nameof(Installment)}: {Installment}, {nameof(Interest)}: {Interest}, charge: {GetCharge()}";
        }
    }
}