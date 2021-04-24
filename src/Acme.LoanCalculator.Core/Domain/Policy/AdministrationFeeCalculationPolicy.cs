using System;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Policy
{
    public class AdministrationFeeCalculationPolicy : IAdministrationFeeCalculationPolicy
    {
        public Money Calculate(Money due, AdministrationFeeTerms terms)
        {
            if (due == null) throw new ArgumentNullException(nameof(due));
            if (terms == null) throw new ArgumentNullException(nameof(terms));

            var calculatedFee = due * terms.Rate;
            return calculatedFee > terms.MaximumAdministrationFee ? terms.MaximumAdministrationFee : calculatedFee;
        }
    }
}