using System;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Application
{
    public sealed class GeneratePaymentOverviewInput
    {
        public GeneratePaymentOverviewInput(Money dueAmount, Duration paymentPeriod)
        {
            DueAmount = dueAmount ?? throw new ArgumentNullException(nameof(dueAmount));
            PaymentPeriod = paymentPeriod ?? throw new ArgumentNullException(nameof(paymentPeriod));
        }

        public Money DueAmount { get; }

        public Duration PaymentPeriod { get; }
    }
}