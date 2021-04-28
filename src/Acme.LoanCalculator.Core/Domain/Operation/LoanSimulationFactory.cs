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
            var paymentList = _paymentSeriesPolicy.Generate(debt.DueAmount, debt.CyclesCount, terms.CycleInterestRate);
            var paymentPlan =  new PaymentSeries(paymentList);
            return new LoanSimulation(debt.DueAmount, debt.CyclesCount, paymentPlan);
        }
    }
}