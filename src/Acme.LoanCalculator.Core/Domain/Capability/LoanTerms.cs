using System;
using System.ComponentModel;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class LoanTerms : IEquatable<LoanTerms>
    {
        public LoanTerms(Percent annualInterestRate, TimeInterval cycleInterval)
        {
            if (!Enum.IsDefined(typeof(TimeInterval), cycleInterval))
                throw new InvalidEnumArgumentException(nameof(cycleInterval), (int) cycleInterval,
                    typeof(TimeInterval));
            this.AnnualInterestRate = annualInterestRate ?? throw new ArgumentNullException(nameof(annualInterestRate));
            this.CycleInterval = cycleInterval;
        }

        public Percent AnnualInterestRate { get; }

        public TimeInterval CycleInterval { get; }

        public Percent CycleInterestRate =>  CycleInterval == TimeInterval.Year ? AnnualInterestRate : AnnualInterestRate / 12;

        public bool Equals(LoanTerms other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(AnnualInterestRate, other.AnnualInterestRate) && CycleInterval == other.CycleInterval;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is LoanTerms other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AnnualInterestRate, (int) CycleInterval);
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