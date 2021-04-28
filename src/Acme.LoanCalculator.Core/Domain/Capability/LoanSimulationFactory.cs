using System;
using Acme.LoanCalculator.Core.Domain.Policy;

namespace Acme.LoanCalculator.Core.Domain.Capability
{
    public class LoanSimulationFactory
    {
        private readonly IInstallmentListGenerationPolicy _installmentListGenerationPolicy;

        public LoanSimulationFactory(IInstallmentListGenerationPolicy installmentListGenerationPolicy)
        {
            _installmentListGenerationPolicy = installmentListGenerationPolicy ?? throw new ArgumentNullException(nameof(installmentListGenerationPolicy));
        }

        public LoanSimulation Create(Loan debt, LoanTerms terms)
        {
            var installments = _installmentListGenerationPolicy.Generate(debt.DueAmount, debt.InstallmentsCount, terms.InstallmentInterestRate);
            var installmentPlan =  new InstallmentList(installments);
            return new LoanSimulation(debt.DueAmount, debt.InstallmentsCount, installmentPlan);
        }
    }
}