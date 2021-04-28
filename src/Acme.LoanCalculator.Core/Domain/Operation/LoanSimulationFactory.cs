using System;
using Acme.LoanCalculator.Core.Domain.Capability;
using Acme.LoanCalculator.Core.Domain.Policy;

namespace Acme.LoanCalculator.Core.Domain.Operation
{
    public class LoanSimulationFactory
    {
        private readonly IPaymentSeriesPolicy _paymentSeriesPolicy;

        public LoanSimulationFactory(IPaymentSeriesPolicy paymentSeriesPolicy)
        {
            _paymentSeriesPolicy = paymentSeriesPolicy ?? throw new ArgumentNullException(nameof(paymentSeriesPolicy));
        }

        LoanSimulation Create(Loan debt, LoanTerms terms)
        {
            var payments = _paymentSeriesPolicy.Generate(debt.Amount, debt.CyclesCount, terms.CycleInterestRate);
            var paymentsPlan =  new PaymentSeries(payments);
            return new LoanSimulation(debt, paymentsPlan);
        }
    }
}