using System;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Policy
{
    public class SimpleAopPolicy : IAopPolicy
    {
        public Percent Calculate(Money debt, Money totalInterest, Money commission, Period duration)
        {
            if (debt == null) throw new ArgumentNullException(nameof(debt));
            if (totalInterest == null) throw new ArgumentNullException(nameof(totalInterest));
            if (commission == null) throw new ArgumentNullException(nameof(commission));
            if (duration == null) throw new ArgumentNullException(nameof(duration));

            Money.AssertIsCurrencyTheSame(debt, totalInterest);
            Money.AssertIsCurrencyTheSame(totalInterest, commission);

            var totalCost = totalInterest + commission;
            var years = duration.Years;
            var yearlyCost = totalCost / years;

            var aopRatio = yearlyCost / debt;

            return new Percent(aopRatio);
        }
    }
}