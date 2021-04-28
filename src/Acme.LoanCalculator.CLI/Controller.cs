using System;
using Acme.LoanCalculator.Core.Application;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.CLI
{
    public sealed class Controller
    {
        private ICalculateLoanPaymentOverviewUseCase _useCase;

        public Controller(ICalculateLoanPaymentOverviewUseCase useCase)
        {
            _useCase = useCase ?? throw new ArgumentNullException(nameof(useCase));
        }

        public void CalculateLoan(decimal dueAmount, int cyclesCount)
        {
            var input = new CalculateLoanInput(new Money(dueAmount, Currency.DanishCrone), new NaturalQuantity(cyclesCount));
            _useCase.Execute(input);
        }
    }
}