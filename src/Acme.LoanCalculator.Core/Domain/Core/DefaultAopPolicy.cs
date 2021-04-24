using System;
using Acme.LoanCalculator.Core.Domain.Generic;

namespace Acme.LoanCalculator.Core.Domain.Core
{
    public class DefaultAopPolicy : IAopPolicy
    {
        public PercentRate Calculate(Money amount, Money totalInterest, Money commission, MonthsDuration duration)
        {
            if (amount == null) throw new ArgumentNullException(nameof(amount));
            if (totalInterest == null) throw new ArgumentNullException(nameof(totalInterest));
            if (commission == null) throw new ArgumentNullException(nameof(commission));
            if (duration == null) throw new ArgumentNullException(nameof(duration));

            var totalCost = totalInterest + commission;
            var years = duration.Years;
            var yearlyCost = totalCost / years;
            var rate = yearlyCost / amount;

            return new PercentRate(rate);
        }
    }
}