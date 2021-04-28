using System;
using Acme.LoanCalculator.Core.Domain.Policy;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class PaymentOverviewFactory
    {
        private readonly IAopCalculationPolicy _aopCalculationPolicy;
        private readonly ICommissionCalculationPolicy _commissionCalculationPolicy;

        public PaymentOverviewFactory(IAopCalculationPolicy aopCalculationPolicy, ICommissionCalculationPolicy commissionCalculationPolicy)
        {
            _aopCalculationPolicy = aopCalculationPolicy ?? throw new ArgumentNullException(nameof(aopCalculationPolicy));
            _commissionCalculationPolicy = commissionCalculationPolicy ?? throw new ArgumentNullException(nameof(commissionCalculationPolicy));
        }

        public PaymentOverview Create(LoanSimulation simulation, CommissionTerms commissionTerms)
        {
            Money totalInterest = simulation.InstallmentPlan.TotalInterestAmount;
            Money totalAdministrativeFee = _commissionCalculationPolicy.Calculate(simulation.DueAmount, commissionTerms);
            Percent aop = _aopCalculationPolicy.Calculate(simulation.DueAmount, totalInterest, totalAdministrativeFee, simulation.InstallmentsCount);

            return new PaymentOverview(aop, totalInterest, totalAdministrativeFee);
        }
    }
}