using System;
using Acme.LoanCalculator.Core.Domain.Generic;

namespace Acme.LoanCalculator.Core.Domain.Core
{
    public class DefaultCommissionPolicy : ICommissionPolicy
    {
        private readonly PercentRate COMMISION_RATE = new PercentRate(1);
        private readonly Money MAX_COMMISSION = Money.DanishCrones(10000);

        public Money Calculate(Money loanAmount)
        {
            Money.AssertIsCurrencyTheSame(loanAmount, MAX_COMMISSION);

            if (loanAmount == null) throw new ArgumentNullException(nameof(loanAmount));

            var commission = loanAmount * COMMISION_RATE.DecimalRate;

            return commission > MAX_COMMISSION ? MAX_COMMISSION : commission;
        }
    }
}