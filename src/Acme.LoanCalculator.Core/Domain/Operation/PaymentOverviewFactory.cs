using System;
using Acme.LoanCalculator.Core.Domain.Capability;
using Acme.LoanCalculator.Core.Domain.Policy;

namespace Acme.LoanCalculator.Core.Domain.Operation
{
    public sealed class PaymentOverviewFactory
    {
        private readonly IAopPolicy _aopPolicy;
        private readonly ICommissionPolicy _commissionPolicy;

        public PaymentOverviewFactory(IAopPolicy aopPolicy, ICommissionPolicy commissionPolicy)
        {
            _aopPolicy = aopPolicy ?? throw new ArgumentNullException(nameof(aopPolicy));
            _commissionPolicy = commissionPolicy ?? throw new ArgumentNullException(nameof(commissionPolicy));
        }

        PaymentOverview Create(LoanCalculation loanCalculation, CommissionTerms commissionTerms)
        {
            Money totalInterest = loanCalculation.PaymentsPlan.TotalInterest;

            Money totalAdministrativeFee = _commissionPolicy.Calculate(loanCalculation.Debt.Amount, commissionTerms);
            Percent aop = _aopPolicy.Calculate(loanCalculation.Debt.Amount, totalInterest, totalAdministrativeFee, loanCalculation.Debt.CyclesCount);

            return new PaymentOverview(aop, totalInterest, totalAdministrativeFee);
        }
    }
}