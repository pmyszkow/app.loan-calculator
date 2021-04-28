namespace Acme.LoanCalculator.Core.Application
{
    public interface ICalculateLoanPaymentOverviewUseCase
    {
        void Execute(CalculateLoanInput input);
    }
}