using System;
using Acme.LoanCalculator.Core.Domain.Policy;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public sealed class PaymentOverviewFactory : IPaymentOverviewFactory
    {
        private readonly IAopCalculationPolicy _aopCalculationPolicy;
        private readonly IAdministrationFeeCalculationPolicy _administrationFeeCalculationPolicy;

        public PaymentOverviewFactory(IAopCalculationPolicy aopCalculationPolicy, IAdministrationFeeCalculationPolicy administrationFeeCalculationPolicy)
        {
            _aopCalculationPolicy = aopCalculationPolicy ?? throw new ArgumentNullException(nameof(aopCalculationPolicy));
            _administrationFeeCalculationPolicy = administrationFeeCalculationPolicy ?? throw new ArgumentNullException(nameof(administrationFeeCalculationPolicy));
        }

        public PaymentOverview Create(LoanSimulation simulation, AdministrationFeeTerms administrationFeeTerms)
        {
            Money totalInterest = simulation.InstallmentPlan.TotalInterestAmount;
            Money totalAdministrativeFee = _administrationFeeCalculationPolicy.Calculate(simulation.DueAmount, administrationFeeTerms);
            Percent aop = _aopCalculationPolicy.Calculate(simulation.DueAmount, totalInterest, totalAdministrativeFee, simulation.InstallmentsCount);

            return new PaymentOverview(aop, totalInterest, totalAdministrativeFee);
        }
    }
}