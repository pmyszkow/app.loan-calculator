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

        PaymentOverview Create(LoanSimulation simulation, CommissionTerms terms)
        {
            Money totalInterest = simulation.PaymentPlan.TotalInterest;
            Money totalAdministrativeFee = _commissionPolicy.Calculate(simulation.DueAmount, terms);
            Percent aop = _aopPolicy.Calculate(simulation.DueAmount, totalInterest, totalAdministrativeFee, simulation.CyclesCount);

            return new PaymentOverview(aop, totalInterest, totalAdministrativeFee);
        }
    }
}