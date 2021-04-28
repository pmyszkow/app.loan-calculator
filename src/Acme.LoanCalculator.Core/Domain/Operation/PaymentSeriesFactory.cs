using System;
using Acme.LoanCalculator.Core.Domain.Capability;
using Acme.LoanCalculator.Core.Domain.Policy;

namespace Acme.LoanCalculator.Core.Domain.Operation
{
    public class PaymentSeriesFactory
    {
        private readonly IPaymentSeriesPolicy _paymentSeriesPolicy;

        public PaymentSeriesFactory(IPaymentSeriesPolicy paymentSeriesPolicy)
        {
            _paymentSeriesPolicy = paymentSeriesPolicy ?? throw new ArgumentNullException(nameof(paymentSeriesPolicy));
        }

        public PaymentSeries Create(Loan debt, LoanTerms debtTerms)
        {
            var payments = _paymentSeriesPolicy.Generate(debt.DueAmount, debt.CyclesCount, debtTerms.CycleInterestRate);
            return new PaymentSeries(payments);
        }
    }
}