using System;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Application
{
    public sealed class GeneratePaymentOverviewInput
    {
        public GeneratePaymentOverviewInput(Money dueAmount, NaturalQuantity installmentsCount)
        {
            DueAmount = dueAmount ?? throw new ArgumentNullException(nameof(dueAmount));
            InstallmentsCount = installmentsCount ?? throw new ArgumentNullException(nameof(installmentsCount));
        }

        public Money DueAmount { get; }

        public NaturalQuantity InstallmentsCount { get; }
    }
}