using System;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Policy
{
    public class SimpleAopPolicy : IAopPolicy
    {
        public Percent Calculate(Money due, Money totalInterest, Money commission, NaturalQuantity monthsCount)
        {
            if (due == null) throw new ArgumentNullException(nameof(due));
            if (totalInterest == null) throw new ArgumentNullException(nameof(totalInterest));
            if (commission == null) throw new ArgumentNullException(nameof(commission));
            if (monthsCount == null) throw new ArgumentNullException(nameof(monthsCount));

            var totalCost = totalInterest + commission;
            var years = monthsCount.Value / 12m;
            var yearlyCost = totalCost / years;

            var aopRatio = yearlyCost / due;

            return new Percent(aopRatio);
        }
    }
}