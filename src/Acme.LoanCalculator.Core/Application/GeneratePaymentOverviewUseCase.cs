using System;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Application
{
    public sealed class GeneratePaymentOverviewUseCase : IGeneratePaymentOverviewUseCase
    {
        private readonly IOutputPort _outputPort;
        private readonly IConfigurationPort _configurationPort;
        private readonly ILoanSimulationFactory _loanSimulationFactory;
        private readonly IPaymentOverviewFactory _paymentOverviewFactory;
        
        public GeneratePaymentOverviewUseCase(IOutputPort outputPort, IConfigurationPort configurationPort, ILoanSimulationFactory loanSimulationFactory, IPaymentOverviewFactory paymentOverviewFactory)
        {
            _outputPort = outputPort ?? throw new ArgumentNullException(nameof(outputPort));
            _configurationPort = configurationPort ?? throw new ArgumentNullException(nameof(configurationPort));
            _loanSimulationFactory = loanSimulationFactory ?? throw new ArgumentNullException(nameof(loanSimulationFactory));
            _paymentOverviewFactory = paymentOverviewFactory ?? throw new ArgumentNullException(nameof(paymentOverviewFactory));
        }

        public void Execute(GeneratePaymentOverviewInput input)
        {
            var loan = new Loan(input.DueAmount, input.InstallmentsCount);

            var loanTerms = new LoanTerms(_configurationPort.AnnualInterestRate, _configurationPort.InstallmentInterval);

            var loanSimulation = _loanSimulationFactory.Create(loan, loanTerms);

            var administrationFeeTerms =  new AdministrationFeeTerms(_configurationPort.AdministrationFeeRate, _configurationPort.MaximumAdministrationFee);

            var paymentOverview = _paymentOverviewFactory.Create(loanSimulation, administrationFeeTerms);

            var output = new PaymentOverviewOutput(loan.DueAmount,
                loan.InstallmentsCount,
                loanTerms.AnnualInterestRate,
                loanTerms.InstallmentInterval,
                administrationFeeTerms.Rate,
                administrationFeeTerms.MaximumAdministrationFee,
                paymentOverview.Aop,
                paymentOverview.TotalInterestAmount,
                paymentOverview.TotalAdministrationFee);

            _outputPort.Write(output);
        }
    }
}