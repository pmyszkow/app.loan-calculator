using System;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Application
{
    public class PaymentOverviewOutput
    {
        public PaymentOverviewOutput(Percent aop, Money totalInterest, Money totalCommission, Money dueAmount, NaturalQuantity cyclesCount, Percent annualInterestRate, TimeInterval paymentsInterval, Percent commisionRate, Money maximumCommision)
        {
            Aop = aop ?? throw new ArgumentNullException(nameof(aop));
            TotalInterest = totalInterest ?? throw new ArgumentNullException(nameof(totalInterest));
            TotalCommission = totalCommission ?? throw new ArgumentNullException(nameof(totalCommission));
            DueAmount = dueAmount ?? throw new ArgumentNullException(nameof(dueAmount));
            CyclesCount = cyclesCount ?? throw new ArgumentNullException(nameof(cyclesCount));
            AnnualInterestRate = annualInterestRate ?? throw new ArgumentNullException(nameof(annualInterestRate));
            PaymentsInterval = paymentsInterval;
            CommisionRate = commisionRate ?? throw new ArgumentNullException(nameof(commisionRate));
            MaximumCommision = maximumCommision ?? throw new ArgumentNullException(nameof(maximumCommision));
        }

        public Money DueAmount { get; }

        public NaturalQuantity CyclesCount { get; }

        public Percent AnnualInterestRate { get; }

        public TimeInterval PaymentsInterval { get; }

        public Percent CommisionRate { get; }

        public Money MaximumCommision { get; }

        public Percent Aop { get; }

        public Money TotalInterest { get; }

        public Money TotalCommission { get; }
    }
}