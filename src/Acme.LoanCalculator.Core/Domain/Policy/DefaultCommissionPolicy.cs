using System;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Domain.Policy
{
    public class DefaultCommissionPolicy : ICommissionPolicy
    {
        public Money Calculate(Money due, CommissionTerms terms)
        {
            if (due == null) throw new ArgumentNullException(nameof(due));
            if (terms == null) throw new ArgumentNullException(nameof(terms));

            var calculatedCommission = due * terms.Rate;
            return calculatedCommission > terms.MaximumCommission ? terms.MaximumCommission : calculatedCommission;
        }
    }
}