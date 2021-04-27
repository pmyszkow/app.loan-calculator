using System;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Policy
{
    public class DefaultCommissionPolicy : ICommissionPolicy
    {
        public Money Calculate(Money debt, Percent commissionRate, Money maximumCommission)
        {
            if (debt == null) throw new ArgumentNullException(nameof(debt));
            if (commissionRate == null) throw new ArgumentNullException(nameof(commissionRate));
            if (maximumCommission == null) throw new ArgumentNullException(nameof(maximumCommission));

            Money.AssertIsCurrencyTheSame(debt, maximumCommission);

            var calculatedCommission = debt * commissionRate;
            return calculatedCommission > maximumCommission ? maximumCommission : calculatedCommission;
        }
    }
}