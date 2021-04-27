using System;
using Acme.LoanCalculator.Core.Domain.Capability;
using Acme.LoanCalculator.Core.Domain.Policy;

namespace Acme.LoanCalculator.Core.Domain.Operation
{
    public sealed class PaymentOverviewFactory
    {
        private readonly IAopPolicy _aopPolicy;
        private readonly ICommissionPolicy _commissionPolicy;
        private readonly IPaymentSeriesPolicy _paymentSeriesPolicy;

        public PaymentOverviewFactory(IAopPolicy aopPolicy, ICommissionPolicy commissionPolicy, IPaymentSeriesPolicy paymentSeriesPolicy)
        {
            _aopPolicy = aopPolicy ?? throw new ArgumentNullException(nameof(aopPolicy));
            _commissionPolicy = commissionPolicy ?? throw new ArgumentNullException(nameof(commissionPolicy));
            _paymentSeriesPolicy = paymentSeriesPolicy ?? throw new ArgumentNullException(nameof(paymentSeriesPolicy));
        }

        PaymentOverview Calculate(Money debt, Period duration, Percent annualInterestRate)
    }
}