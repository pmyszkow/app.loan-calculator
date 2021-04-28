using System;
using Acme.LoanCalculator.Core.Application;
using Acme.LoanCalculator.Core.Domain.Capability;

namespace Acme.LoanCalculator.CLI
{
    public sealed class PaymentOverviewController
    {
        private IGeneratePaymentOverviewUseCase _useCase;

        public PaymentOverviewController(IGeneratePaymentOverviewUseCase useCase)
        {
            _useCase = useCase ?? throw new ArgumentNullException(nameof(useCase));
        }

        public void Generate(decimal dueValue, int installmentsCount)
        {
            var input = new GeneratePaymentOverviewInput(
                new Money(dueValue, Currency.DanishCrone),
                new NaturalQuantity(installmentsCount)
            );

            _useCase.Execute(input);
        }
    }
}