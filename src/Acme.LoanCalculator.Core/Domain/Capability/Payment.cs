using System;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class Payment : IEquatable<Payment>
    {
        public Payment(int cycleNumber, Money installment, Money interest)
        {
            Money.AssertIsCurrencyTheSame(installment,interest);
            CycleNumber = cycleNumber;
            Installment = installment ?? throw new ArgumentNullException(nameof(installment));
            Interest = interest ?? throw new ArgumentNullException(nameof(interest));
        }

        public static Payment FromTotalAndInterest(int cycleNumber, Money charge, Money interest)
        {
            if (charge == null) throw new ArgumentNullException(nameof(charge));
            if (interest == null) throw new ArgumentNullException(nameof(interest));

            return new Payment(cycleNumber, charge - interest, interest);
        }

        public int CycleNumber { get; }

        public Money Installment { get; }

        public Money Interest { get; }

        public Money Total => Installment + Interest;

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
            return CycleNumber == other.CycleNumber && Equals(Installment, other.Installment) && Equals(Interest, other.Interest);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Payment other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CycleNumber, Installment, Interest);
        }

        public override string ToString()
        {
            return $"{nameof(Payment)} no. {CycleNumber}, {nameof(Installment)}: {Installment}, {nameof(Interest)}: {Interest}, total: {Total}";
        }
    }
}