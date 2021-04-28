using System;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Policy
{
    public class AopCalculationPolicy : IAopCalculationPolicy
    {
        public Percent Calculate(Money due, Money totalInterest, Money administrationFee, NaturalQuantity monthsCount)
        {
            if (due == null) throw new ArgumentNullException(nameof(due));
            if (totalInterest == null) throw new ArgumentNullException(nameof(totalInterest));
            if (administrationFee == null) throw new ArgumentNullException(nameof(administrationFee));
            if (monthsCount == null) throw new ArgumentNullException(nameof(monthsCount));

            var totalCost = totalInterest + administrationFee;
            var years = monthsCount.Value / 12m;
            var yearlyCost = totalCost / years;

            var aopRatio = yearlyCost / due;

            return new Percent(aopRatio);
        }
    }
}