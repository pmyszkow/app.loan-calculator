using System;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class Installment : IEquatable<Installment>
    {
        public Installment(NaturalQuantity installmentNumber, Money capitalPart, Money interestPart)
        {
            InstallmentNumber = installmentNumber ?? throw new ArgumentNullException(nameof(installmentNumber));
            CapitalPart = capitalPart ?? throw new ArgumentNullException(nameof(capitalPart));
            InterestPart = interestPart ?? throw new ArgumentNullException(nameof(interestPart));

            Money.AssertIsCurrencyTheSame(capitalPart, interestPart);
        }

        public static Installment FromTotalAmountAndInterestPart(NaturalQuantity cycleNumber, Money totalAmount, Money interestPart)
        {
            if (totalAmount == null) throw new ArgumentNullException(nameof(totalAmount));
            if (interestPart == null) throw new ArgumentNullException(nameof(interestPart));

            return new Installment(cycleNumber, totalAmount - interestPart, interestPart);
        }

        public NaturalQuantity InstallmentNumber { get; }

        public Money CapitalPart { get; }

        public Money InterestPart { get; }

        public Money TotalAmount => CapitalPart + InterestPart;

        public static bool operator ==(Installment left, Installment right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Installment left, Installment right)
        {
            return !Equals(left, right);
        }

        public bool Equals(Installment other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return InstallmentNumber == other.InstallmentNumber && Equals(CapitalPart, other.CapitalPart) && Equals(InterestPart, other.InterestPart);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Installment other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(InstallmentNumber, CapitalPart, InterestPart);
        }

        public override string ToString()
        {
            return $"{nameof(Installment)} no. {InstallmentNumber}, {nameof(CapitalPart)}: {CapitalPart}, {nameof(InterestPart)}: {InterestPart}, total amount: {TotalAmount}";
        }
    }
}