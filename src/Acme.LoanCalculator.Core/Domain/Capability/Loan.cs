using System;
using System.ComponentModel;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class Loan : IEquatable<Loan>
    {
        public Loan(Money dueAmount, Duration paymentPeriod)
        {
            DueAmount = dueAmount ?? throw new ArgumentNullException(nameof(dueAmount));
            PaymentPeriod = paymentPeriod ?? throw new ArgumentNullException(nameof(paymentPeriod));
        }

        public Money DueAmount { get; }

        public Duration PaymentPeriod { get; }

        public NaturalQuantity InstallmentsCount(TimeInterval installmentInterval)
        {
            if (!Enum.IsDefined(typeof(TimeInterval), installmentInterval))
                throw new InvalidEnumArgumentException(nameof(installmentInterval), (int) installmentInterval,
                    typeof(TimeInterval));

            return installmentInterval == TimeInterval.Month ? PaymentPeriod.TotalMonths : PaymentPeriod.TotalYears;
        }

        public bool Equals(Loan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(DueAmount, other.DueAmount) && Equals(PaymentPeriod, other.PaymentPeriod);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Loan other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DueAmount, PaymentPeriod);
        }

        public static bool operator ==(Loan left, Loan right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Loan left, Loan right)
        {
            return !Equals(left, right);
        }
    }
}