using System;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.Core.Application
{
    public sealed class CalculateLoanInput
    {
        public CalculateLoanInput(Money dueAmount, NaturalQuantity cyclesCount)
        {
            DueAmount = dueAmount ?? throw new ArgumentNullException(nameof(dueAmount));
            CyclesCount = cyclesCount ?? throw new ArgumentNullException(nameof(cyclesCount));
        }

        public Money DueAmount { get; }

        public NaturalQuantity CyclesCount { get; }
    }
}