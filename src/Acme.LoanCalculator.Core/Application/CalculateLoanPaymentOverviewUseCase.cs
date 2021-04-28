using System;
using Acme.LoanCalculator.Core.Domain.Capability;
using Acme.LoanCalculator.Core.Domain.Policy;

namespace Acme.LoanCalculator.Core.Application
{
    public sealed class CalculateLoanPaymentOverviewUseCase : ICalculateLoanPaymentOverviewUseCase
    {
        private readonly IPresenter _presenter;
        private readonly IConfigurationPort _configurationPort;

        private readonly LoanSimulationFactory _loanSimulationFactory =
            new LoanSimulationFactory(new InstallmentListGenerationPolicy());

        private readonly PaymentOverviewFactory _paymentOverviewFactory =
            new PaymentOverviewFactory(new AopCalculationPolicy(), new CommissionCalculationPolicy());

        public CalculateLoanPaymentOverviewUseCase(IPresenter presenter, IConfigurationPort configurationPort)
        {
            _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
            _configurationPort = configurationPort ?? throw new ArgumentNullException(nameof(configurationPort));
        }

        public void Execute(CalculateLoanInput input)
        {
            var debt = new Loan(input.DueAmount, input.CyclesCount);

            var terms = new LoanTerms(_configurationPort.AnnualInterestRate, _configurationPort.PaymentInterval);

            var simulation = _loanSimulationFactory.Create(debt, terms);

            var commisionTerms =  new CommissionTerms(_configurationPort.CommisionRate, _configurationPort.MaximumCommision);

            var paymentOverview = _paymentOverviewFactory.Create(simulation, commisionTerms);

            var output = new PaymentOverviewOutput(paymentOverview.Aop, paymentOverview.TotalInterestAmount,
                paymentOverview.TotalAdministrativeFee, debt.DueAmount, debt.InstallmentsCount, terms.AnnualInterestRate,
                terms.InstallmentInterval, commisionTerms.Rate, commisionTerms.MaximumCommission);

            _presenter.Display(output);

        }
    }
}