using System;
using System.ComponentModel;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class LoanTerms : IEquatable<LoanTerms>
    {
        public LoanTerms(Percent annualInterestRate, TimeInterval installmentInterval)
        {
            if (!Enum.IsDefined(typeof(TimeInterval), installmentInterval))
                throw new InvalidEnumArgumentException(nameof(installmentInterval), (int) installmentInterval,
                    typeof(TimeInterval));
            this.AnnualInterestRate = annualInterestRate ?? throw new ArgumentNullException(nameof(annualInterestRate));
            this.InstallmentInterval = installmentInterval;
        }

        public Percent AnnualInterestRate { get; }

        public TimeInterval InstallmentInterval { get; }

        public Percent InstallmentInterestRate =>  InstallmentInterval == TimeInterval.Year ? AnnualInterestRate : AnnualInterestRate / 12m;

        public bool Equals(LoanTerms other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(AnnualInterestRate, other.AnnualInterestRate) && InstallmentInterval == other.InstallmentInterval;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is LoanTerms other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AnnualInterestRate, (int) InstallmentInterval);
        }

        public static bool operator ==(LoanTerms left, LoanTerms right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LoanTerms left, LoanTerms right)
        {
            return !Equals(left, right);
        }
    }
}