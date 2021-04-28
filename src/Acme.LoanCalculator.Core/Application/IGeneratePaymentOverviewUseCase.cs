namespace Acme.LoanCalculator.Core.Application
{
    public interface IGeneratePaymentOverviewUseCase
    {
        void Execute(GeneratePaymentOverviewInput input);
    }
}